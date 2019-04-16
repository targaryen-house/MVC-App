using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MVCswitchback.Models;
using MVCswitchback.Models.Interfaces;
using Newtonsoft.Json;

namespace MVCswitchback.Controllers
{

    public class TrailController : Controller
    {
        private readonly ITrail _trails;

        public TrailController(ITrail trails)
        {
            _trails = trails;
        }

        static HttpClient client = new HttpClient();


        public async Task<IActionResult> Index(string SearchString)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://switchbackapi.azurewebsites.net");
                    var response = client.GetAsync($"/api/{SearchString}").Result;
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

        public async Task<IActionResult> Details(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }
            var trail = await _trails.GetTrail(id);
            if (trail == null)
            {
                return NotFound();
            }
            return View(trail);
        } 
    }
}