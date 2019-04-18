using Microsoft.Extensions.Configuration;
using MVCswitchback.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MVCswitchback.Models.Services;
using MVCswitchback.Models.Interfaces;

namespace MVCswitchback.Controllers
{
    public class BackendAPI
    {
        private readonly IConfiguration Configuration;

        /// <summary>
        /// Sends Request for data from our API
        /// </summary>
        /// <param name="lat"> Latitude Data </param>
        /// <param name="lon"> Longitude Data </param>
        /// <returns></returns>
        public static async Task<List<Trail>> GetTrailsAsync(string SearchString)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            var response = client.GetAsync($"/api/bing?query={SearchString}").Result;
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            //List<Rootobject> rawTrail = JsonConvert.DeserializeObject<List<Rootobject>>(stringResult);
            var testTrail = JsonConvert.DeserializeObject<List<Trail>>(stringResult);
            return testTrail;
        }

        /// <summary>
        /// Queries the ID data for a particular trail from our API
        /// </summary>
        /// <param name="id"> ID of trail </param>
        /// <returns> A trail "singletrail" </returns>
        public static async Task<Trail> GetTrailByID(int id)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net");
            var response = client.GetAsync($"/api/trail/{id}").Result;
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            Trail rawTrail = JsonConvert.DeserializeObject<Trail>(stringResult);
            Trail singletrail = rawTrail;
            return singletrail;

            // Call our API
            //client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            //var response = client.GetAsync($"api/trails/{id}").Result;
            //response.EnsureSuccessStatusCode();

            //var stringResult = await response.Content.ReadAsStringAsync();
            //Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
            //Trail singletrail = rawTrail.Trails[0];
            //return singletrail;
        }

        /// <summary>
        /// Creates trail and posts it to the page
        /// </summary>
        /// <param name="trail"> a newly created trail </param>
        /// <returns> Returns the location and page of the newly created trail </returns>
        public static async Task<Uri> CreateTrailAsync(Trail trail)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PostAsJsonAsync("api/trails", trail);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        /// <summary>
        ///  Updates a selected trail
        /// </summary>
        /// <param name="trail"> a trail Identifier </param>
        /// <returns> returns an updated trail </returns>
        public static async Task<Trail> UpdateTrailAsync(Trail trail)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/trails/{trail.ID}", trail);
            response.EnsureSuccessStatusCode();

            trail = await response.Content.ReadAsAsync<Trail>();
            return trail;
        }

        /// <summary>
        /// Deletes Selected trail
        /// </summary>
        /// <param name="id"> id of trail </param>
        /// <returns> a response message of deletion </returns>
        public static async Task<HttpStatusCode> DeleteTrailAsync(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.DeleteAsync($"api/trails/{id}");
            return response.StatusCode;
        }
      
        public static async Task<WeatherResponse> GetWeather(float lat, float lon, IConfiguration configuration)

        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync($"/data/2.5/weather?lat={lat}&lon={lon}&appid={configuration["OpenAPIKey"]}");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);

                Weather weather = new Weather()
                {
                    Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main))
                };
                return weather;
            }

        }

    }
}
