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
        public async Task<IActionResult> Index(float lat, float lon)
        {
            Rootobject trails = await BackendAPI.GetTrailsAsync(lat, lon);
            return View(trails);
        }

        public async Task<IActionResult> Details(int id)
        {
            Trail trail = await BackendAPI.GetTrailByID(id);
            return View(trail);

        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Trail trail)
        {
            Trail returnTrail = await BackendAPI.UpdateTrailAsync(trail);
            return View(returnTrail);
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}