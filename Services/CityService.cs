using AirQuality.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirQuality.Services
{
    public class CityService : ICityService
    {

        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly HttpClient client;

        public CityService(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("OpenAQApi");
        }

        public async Task<Root> GetAllCities(string city)
        {
            var url = string.Format("cities?limit=1000&page=1&offset=0&sort=asc&order_by=city&city={0}", city);
            var result = new Root();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                
                result = JsonSerializer.Deserialize<Root>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
        public async Task<Root> GetAllCountries(string country)
        {
            var url = string.Format("countries?limit=200&page=1&offset=0&sort=asc&country={0}", country);
            var result = new Root();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<Root>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

    }

}
