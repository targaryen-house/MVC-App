using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MVCswitchback.Models;
using Newtonsoft.Json;

namespace MVCswitchback.Controllers
{

    public class TrailController : Controller
    {

        static HttpClient client = new HttpClient();


        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://www.hikingproject.com");
                    var response = client.GetAsync($"/data/get-trails?lat=40.0274&lon=-105.2519&maxDistance=10&key=200426075-bb9e04f2cd93ffc60dd2762d4f81ff2b").Result;
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    Rootobject rawTrail = JsonConvert.DeserializeObject<Rootobject>(stringResult);
                    return View(rawTrail);
                }
                catch (HttpRequestException httpRequestException)
                {

                    return BadRequest($"Error getting information from Switchback: {httpRequestException}");
                }
            }
        }



        //static void ShowTrails(Trail trail)
        //{
        //    Console.WriteLine($"Name: {trail.name}");
        //}

        //static async Task<Uri> CreateTrailAsync(Trail trail)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync("api/trail", trail);
        //    response.EnsureSuccessStatusCode();

        //    return URI or the created resource.
        //    return response.Headers.Location;
        //}
        //static async Task<Trail> GetTrailAsync(string path)
        //{
        //    Trail trail = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        trail = await response.Content.ReadAsAsync<Trail>();
        //    }
        //    return trail;
        //}
        //static async Task<Trail> UpdateTrailAsync(Trail trail)
        //{
        //    HttpResponseMessage response = await client.PutAsJsonAsync($"api/trails/{trail.id}", trail);
        //    response.EnsureSuccessStatusCode();

        //    Deserialize the updatet trail from the response body
        //    trail = await response.Content.ReadAsAsync<Trail>();
        //    return trail;
        //}
        //static async Task<HttpStatusCode> DeleteTrailAsync(string id)
        //{
        //    HttpResponseMessage response = await client.DeleteAsync($"api/trails/{id}");
        //    return response.StatusCode;
        //}

    }
}