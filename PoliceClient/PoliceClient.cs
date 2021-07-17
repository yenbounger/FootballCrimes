using Microsoft.AspNetCore.WebUtilities;
using Police.Client.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PoliceClient
{
    public class PoliceDataClient
    {
        private string POLICEENDPOINT = "https://data.police.uk/api/crimes-at-location";
        private readonly DateTime MaxDate = DateTime.Now.AddMonths(-1);
        private readonly DateTime MinDate = new(2018, 06, 01);

        private HttpClient _httpClient;
        public PoliceDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RawPoliceData>> GetDataForTimeAndPlace(double longi, double lati, DateTime date)
        {
            if (date.CompareTo(MinDate) < 0 || date.CompareTo(MaxDate) > 0)
            {
                throw new Exception($"Date cannot be before 01/06/2018 or after the current day");
            }
            try
            {
                var dateString = date.ToString("yyyy-MM");
                var uri = QueryHelpers.AddQueryString(POLICEENDPOINT, "date", date.ToString("yyyy-MM"));
                uri = QueryHelpers.AddQueryString(uri, "lat", lati.ToString());
                uri = QueryHelpers.AddQueryString(uri, "lng", longi.ToString());
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<RawPoliceData>>(jsonString);
                }
                else
                {
                    // Would add logging here
                    var body = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Non-Successful response from Police API. Code: {response.StatusCode}, Body: {body}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
