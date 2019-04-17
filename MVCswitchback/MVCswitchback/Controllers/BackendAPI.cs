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

        public static async Task<Rootobject> GetTrailsAsync(float lat, float lon)
        {
            HttpClient client = new HttpClient();

            // Call Hikingproject API
            client.BaseAddress = new Uri("https://www.hikingproject.com");
            var response = client.GetAsync($"/data/get-trails?lat=40.0274&lon=-105.2519&maxDistance=10&key=200426075-bb9e04f2cd93ffc60dd2762d4f81ff2b").Result;
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
            return rawTrail;

            // Call our API
            //client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            //var response = client.GetAsync($"api/bing/").Result;
            //response.EnsureSuccessStatusCode();

            //var stringResult = await response.Content.ReadAsStringAsync();
            //Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
            //return rawTrail;
        }
        public static async Task<Trail> GetTrailByID(int id)
        {
            HttpClient client = new HttpClient();

            // Call Hikingproject API
            client.BaseAddress = new Uri("https://www.hikingproject.com");
            var response = client.GetAsync($"/data/get-trails-by-id?ids={id}&key=200426075-bb9e04f2cd93ffc60dd2762d4f81ff2b").Result;
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
            Trail singletrail = rawTrail.Trails[0];
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
        public static async Task<Uri> CreateTrailAsync(Trail trail)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PostAsJsonAsync("api/trails", trail);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<Trail> UpdateTrailAsync(Trail trail)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/trails/{trail.ID}", trail);
            response.EnsureSuccessStatusCode();

            trail = await response.Content.ReadAsAsync<Trail>();
            return trail;
        }
        public static async Task<HttpStatusCode> DeleteTrailAsync(string id)
        {
            HttpClient client = new HttpClient();

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

        public static async Task<List<UserReviews>> GetReviews(int id)
        {
            GetUserReviews
        }

    }
}
