﻿using Microsoft.Extensions.Configuration;
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
        }

        /// <summary>
        /// Creates trail async
        /// </summary>
        /// <param name="trail"> a new created trail </param>
        /// <returns> Returns the location </returns>
        public static async Task<Uri> CreateTrailAsync(Trail trail)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PostAsJsonAsync("api/trail", trail);
            
            return response.Headers.Location;
        }

        /// <summary>
        ///  Updates a particular trail
        /// </summary>
        /// <param name="trail"> a trail </param>
        /// <returns> updated trail </returns>
        public static async Task<Trail> UpdateTrailAsync(Trail trail)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/trail/{trail.ID}", trail);
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
            HttpResponseMessage response = await client.DeleteAsync($"api/trail/{id}");
            return response.StatusCode;
        }
      
        public static async Task<Weather> GetWeather(float lat, float lon, IConfiguration configuration)

        {
            using (HttpClient client = new HttpClient())
            {
                var key = ($"/data/2.5/weather?lat={lat}&lon={lon}&appid={configuration["OpenAPIKey"]}");
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await client.GetAsync(key);
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
