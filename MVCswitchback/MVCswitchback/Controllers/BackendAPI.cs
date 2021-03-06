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
            var stringResult = await response.Content.ReadAsStringAsync();
            var testTrail = JsonConvert.DeserializeObject<List<Trail>>(stringResult);
            return testTrail;
        }

        /// <summary>
        /// Queries the ID data for a particular trail from our API
        /// </summary>
        /// <param name="id"> ID of trail </param>
        /// <returns> Returns a selected trail </returns>
        public static async Task<Trail> GetTrailByID(int id)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net");
            var response = client.GetAsync($"/api/trail/{id}").Result;

            var stringResult = await response.Content.ReadAsStringAsync();
            Trail rawTrail = JsonConvert.DeserializeObject<Trail>(stringResult);
            Trail singletrail = rawTrail;

            return singletrail;
        }

        public static async Task<Trail> GetTrailByName(float name)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net");
            var response = client.GetAsync($"/api/trail?trailLength={name}").Result;

            var stringResult = await response.Content.ReadAsStringAsync();
            Trail rawTrail = JsonConvert.DeserializeObject<Trail>(stringResult);
            Trail singletrail = rawTrail;

            return singletrail;
        }

        /// <summary>
        /// Creates trail and posts it to the page
        /// </summary>
        /// <param name="trail">  Identifies the trail in relation to a newly created trail </param>
        /// <returns> Returns the location and page of the newly created trail </returns>
        public static async Task<Uri> CreateTrailAsync(Trail trail)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net");
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/trail", trail);
            return response.Headers.Location;
        }

        /// <summary>
        ///  Updates a selected trail
        /// </summary>
        /// <param name="trail"> Identifies the trail in relation to a newly modified trail </param>
        /// <returns> returns an updated trail </returns>
        public static async Task<Trail> UpdateTrailAsync(Trail trail)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net");
            HttpResponseMessage response = await client.PutAsJsonAsync($"/api/trail/{trail.TrailID}", trail);
            Trail returnTrail = await GetTrailByID(trail.TrailID);
            return returnTrail;
        }

        /// <summary>
        /// Deletes Selected trail
        /// </summary>
        /// <param name="id"> id of trail </param>
        /// <returns> a response message of deletion </returns>
        public static async Task<HttpStatusCode> DeleteTrailAsync(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net");
            HttpResponseMessage response = await client.DeleteAsync($"/api/trail/{id}");
            return response.StatusCode;
        }
      
        /// <summary>
        /// Gets the weather in relation to the current search area based on multiple sources of data
        /// </summary>
        /// <param name="lat"> Latitude Data </param>
        /// <param name="lon"> Longitude Data</param>
        /// <param name="configuration"> Identifier for key/value </param>
        /// <returns> Returns the weather of the selected location </returns>
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
