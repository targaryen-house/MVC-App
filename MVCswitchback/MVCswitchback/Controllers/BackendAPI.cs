using MVCswitchback.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCswitchback.Controllers
{
    public class BackendAPI
    {
        static HttpClient client = new HttpClient();

        /// <summary>
        /// Sends Request for data from our API
        /// </summary>
        /// <param name="lat"> Latitude Data </param>
        /// <param name="lon"> Longitude Data </param>
        /// <returns></returns>
        public static async Task<Rootobject> GetTrailsAsync(float lat, float lon)
        {
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            var response = client.GetAsync($"api/bing/").Result;
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
            return rawTrail;
        }

        /// <summary>
        /// Queries the ID data for a particular trail from our API
        /// </summary>
        /// <param name="id"> ID of trail </param>
        /// <returns> A trail "singletrail" </returns>
        public static async Task<Trail> GetTrailByID(int id)
        {
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            var response = client.GetAsync($"api/trails/{id}").Result;
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
            Trail singletrail = rawTrail.Trails[0];
            return singletrail;
        }

        /// <summary>
        /// Creates trail async
        /// </summary>
        /// <param name="trail"> a new created trail </param>
        /// <returns> Returns the location </returns>
        public static async Task<Uri> CreateTrailAsync(Trail trail)
        {
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PostAsJsonAsync("api/trails", trail);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        /// <summary>
        ///  Updates a particular trail
        /// </summary>
        /// <param name="trail"> a trail </param>
        /// <returns> updated trail </returns>
        public static async Task<Trail> UpdateTrailAsync(Trail trail)
        {
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
        public static async Task<HttpStatusCode> DeleteTrailAsync(string id)
        {
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.DeleteAsync($"api/trails/{id}");
            return response.StatusCode;
        }

        public static async Task<WeatherResponse> GetWeather(float lat, float lon)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync($"/data/2.5/weather?lat={lat}&lon={lon}&appid=cf533494dceec77754749475e189b600");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);

                return rawWeather;
            }
        }
    }
}
