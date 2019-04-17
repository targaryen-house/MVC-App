using MVCswitchback.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCswitchback.Controllers
{
    public class BackendAPI
    {
        public static async Task<Rootobject> GetJObjectAsync(float lat, float lon)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.hikingproject.com");
                var response = client.GetAsync($"/data/get-trails?lat={lat}&lon={lon}&maxDistance=10&key=200426075-bb9e04f2cd93ffc60dd2762d4f81ff2b").Result;
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
                return rawTrail;
            }
        }
        public static async Task<Trail> GetObjectByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("Https://www.hikingproject.com");
                var response = client.GetAsync($"/data/get-trails-by-id?ids={id}&key=200426075-bb9e04f2cd93ffc60dd2762d4f81ff2b").Result;
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
                Trail singletrail = rawTrail.Trails[0];
                return singletrail;
            }
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
