using Postcode.Client.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Postcode.Client
{
    public class PostcodeClient
    {
        private readonly string BASE_API_URL = "https://api.postcodes.io/postcodes";
        private readonly HttpClient _httpClient;

        public PostcodeClient(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }
        public async Task<bool> IsPostcodeValid(string postcode)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{BASE_API_URL}/{postcode}/validate");
                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<RawValidatePostcodeData>(stringResponse).Result;
                }
                else
                {
                    // Would add logging here
                    var body = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Non-Successful response from Postcode.io. Code: {response.StatusCode}, Body: {body}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RawPostcodeData> GetPostcodeData(string postcode)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{BASE_API_URL}/{postcode}");
                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<RawPostcodeData>(stringResponse);
                }
                else
                {
                    // Would add logging here
                    var body = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Non-Successful response from Postcode.io. Code: {response.StatusCode}, Body: {body}");
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
