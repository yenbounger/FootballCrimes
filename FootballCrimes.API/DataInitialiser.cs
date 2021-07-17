using FootballCrimes.API;
using FootballCrimes.API.Models;
using FootballData.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Postcode.Client;
using PoliceClient;
using Police.Client.Model;

namespace FootballCrimes.API
{
    public class DataInitialiser : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DateTime _minPoliceDate = new(2018, 06, 01);
        private readonly DateTime _lastMonth = DateTime.Now.AddMonths(-1);

        public DataInitialiser(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SeedData()
        {
            using var scope = _serviceProvider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<FootballCrimesContext>();
            CreateAndUpdateDatabase(context);
            await AddSeasons(scope, context);
            await ValidatePostcodes(scope, context);
            await AddPositionalData(scope, context);
            await AddCrimeData(scope, context);
        }

        private async Task AddCrimeData(IServiceScope scope, FootballCrimesContext context)
        {
            var crimelessStadiums = context.Stadiums.Where(x => x.Crimes.Count <= 0).ToList();
            var policeDates = new List<DateTime>();
            var startDate = new DateTime(_lastMonth.Year, _lastMonth.Month, 1);
            while (startDate.Month >= _minPoliceDate.Month || startDate.Year > _minPoliceDate.Year)
            {
                policeDates.Add(startDate);
                startDate = startDate.AddMonths(-1);
            }
            var counter = 0;
            foreach (var stadium in crimelessStadiums)
            {
                var policeClient = scope.ServiceProvider.GetRequiredService<PoliceDataClient>();
                foreach (var date in policeDates)
                {
                    var result = await policeClient.GetDataForTimeAndPlace(stadium.Longitude, stadium.Latitude, date);
                    // max 15 requests per 1 second, set max requests to 14 and delay to 1.5 seconds to give some leeway
                    if (counter % 15 == 0)
                    {
                        await Task.Delay(1000);
                    }
                    counter++;
                    if (result.Count > 0)
                    {

                        stadium.AddCrimes(result);
                        context.Update(stadium);
                        context.SaveChanges();
                    }
                }


            }
        }

        private static async Task AddPositionalData(IServiceScope scope, FootballCrimesContext context)
        {
            var noPositionalData = context.Stadiums.Where(x => x.ValidatedPostcode != default && (x.Longitude == default || x.Latitude == default)).ToList();
            foreach (var stadium in noPositionalData)
            {
                var postcodeClient = scope.ServiceProvider.GetRequiredService<PostcodeClient>();
                var postcodeData = await postcodeClient.GetPostcodeData(stadium.ValidatedPostcode);
                stadium.UpdateLongAndLat(postcodeData.Result.Longitude, postcodeData.Result.Latitude);
                context.SaveChanges();
            }
        }

        private static async Task ValidatePostcodes(IServiceScope scope, FootballCrimesContext context)
        {
            var invalidPostcodes = context.Stadiums.Where(x => x.ValidatedPostcode == default).ToList();
            foreach (var stadium in invalidPostcodes)
            {
                var postcodeClient = scope.ServiceProvider.GetRequiredService<PostcodeClient>();
                var isValid = await postcodeClient.IsPostcodeValid(stadium.PostcodeToValidate);
                if (isValid)
                {
                    stadium.AddValidatedPostcode(stadium.PostcodeToValidate);
                }
                context.SaveChanges();
            }
        }

        private static async Task AddSeasons(IServiceScope scope, FootballCrimesContext context)
        {
            var seasonsToAdd = new List<Season>();
            var existingSeasons = context.Seasons.Count();
            if (existingSeasons == 0)
            {
                // Years available from the api
                var years = new List<int> { 2020, 2019, 2018 };
                var dataTasks = new List<Task<RawSeasonData>>();
                years.ForEach(seasonStart =>
                {
                    var footballDataClient = scope.ServiceProvider.GetRequiredService<FootballDataClient>();
                    dataTasks.Add(footballDataClient.GetTeamDataAsync(seasonStart));
                });
                var results = await Task.WhenAll(dataTasks);
                AddTeams(context, seasonsToAdd, results);
            };
        }

        private static void AddTeams(FootballCrimesContext context, List<Season> seasonsToAdd, RawSeasonData[] results)
        {
            foreach (var data in results)
            {
                // Add the season
                var newSeason = new Season(data);
                // Add or update each team to add the season they were in the prem
                data.Teams.ForEach(team =>
                {
                    var existingTeam = context.Teams.FirstOrDefault(x => x.ApiId == team.Id);
                    if (existingTeam == null)
                    {
                        context.Teams.Add(new Team(team, newSeason));
                    }
                    else
                    {
                        existingTeam.AddSeason(newSeason);
                    }
                });

                seasonsToAdd.Add(newSeason);
                context.SaveChanges();

            };
        }

        private static void CreateAndUpdateDatabase(FootballCrimesContext context)
        {
            var migrator = context.Database.GetService<IMigrator>();
            migrator.Migrate();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await SeedData();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}


