using FootballCrimes.API.Config;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballData.Client
{
    public class FootballDataClient
    {
        private string API_TOKEN = "";
        // ToDo: Create Constants Class/move to appsettings
        private string PREMIERLEAGUEDATAENDPOINT = "https://api.football-data.org/v2/competitions/2021/teams";
        private HttpClient _httpClient;

        public FootballDataClient(HttpClient httpClient, IOptions<ApiKeys> apiKeys)
        {
            // Could type appsettings 
            API_TOKEN = apiKeys.Value.FootballData;
            _httpClient = httpClient;
        }

        /// <summary>
        /// Calls the football data API client to get the list of premier league teams for the season starting
        /// in the current year
        /// </summary>
        public async Task<RawSeasonData> GetTeamDataAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, PREMIERLEAGUEDATAENDPOINT);
                return await SendRequest(request);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }



        /// <summary>
        /// Calls the football data api client to get the list of premier league teams 
        /// for the season starting the year provided
        /// </summary>
        /// <param name="year">The year in which the season you wish to get teams for began</param>
        public async Task<RawSeasonData> GetTeamDataAsync(int year)
        {
            // Season 2021 hasn't started yet - should work out if the current year is the start date of the current season if developing further
            // Free tier of football API cannot get data before season starting 2018
            if (year < 2018 || year >= DateTime.Now.Year)
            {
                throw new ArgumentException($"Must be a date between the current year, and the year 2000. Provided: {year}");
            }
            try
            {
                var uri = QueryHelpers.AddQueryString(PREMIERLEAGUEDATAENDPOINT, "season", year.ToString());
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                return await SendRequest(request);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private async Task<RawSeasonData> SendRequest(HttpRequestMessage request)
        {
            request.Headers.Add("X-AUTH-TOKEN", API_TOKEN);
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RawSeasonData>(jsonString);
            }
            else
            {
                // Would add logging here
                var body = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Non-Successful response from Football Data. Code: {response.StatusCode}, Body: {body}");
            }
        }

    }
}
