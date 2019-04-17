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

        public static async Task<Rootobject> GetTrailsAsync(float lat, float lon)
        {
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            var response = client.GetAsync($"api/bing/").Result;
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
            return rawTrail;
        }
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
        public static async Task<Uri> CreateTrailAsync(Trail trail)
        {
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PostAsJsonAsync("api/trails", trail);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<Trail> UpdateTrailAsync(Trail trail)
        {
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/trails/{trail.ID}", trail);
            response.EnsureSuccessStatusCode();

            trail = await response.Content.ReadAsAsync<Trail>();
            return trail;
        }
        public static async Task<HttpStatusCode> DeleteTrailAsync(string id)
        {
            client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net/");
            HttpResponseMessage response = await client.DeleteAsync($"api/trails/{id}");
            return response.StatusCode;
        }
    }
}
