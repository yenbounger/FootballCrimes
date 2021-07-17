using FootballCrimes.API;
using FootballCrimes.API.Models;
using FootballData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.DatabaseInitialiser
{
    public class DatabaseInitialiser
    {
        private readonly FootballCrimesContext _context;
        private readonly FootballDataClient _footballDataClient;

        public DatabaseInitialiser(FootballCrimesContext context, FootballDataClient footballDataClient)
        {
            _context = context;
            _footballDataClient = footballDataClient;
        }
        public List<Season> SeedData()
        {
            var seasonsToAdd = new List<Season>();
            var existingSeasons = _context.Seasons.Count();
            if (existingSeasons == 0)
            {
                // Years available from the api
                var years = new List<int> { 2020, 2019, 2018 };
                years.ForEach(async seasonStart =>
                {
                    var data = await _footballDataClient.GetTeamDataAsync(seasonStart);
                    // Add the season
                    var newSeason = new Season(data);
                    // Add or update each team to add the season they were in the prem
                    data.Teams.ForEach(async team =>
                    {
                        var existingTeam = _context.Teams.FirstOrDefault(x => x.ApiId == team.Id);
                        if (existingTeam == null)
                        {
                            await _context.Teams.AddAsync(new Team(team, newSeason));
                        } else
                        {
                            existingTeam.AddSeason(newSeason);
                        }
                    });

                    await _context.SaveChangesAsync();
                    seasonsToAdd.Add(newSeason);
                });
            }
            return seasonsToAdd;
        }
    }
}
