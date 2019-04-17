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
            Rootobject trails = await BackendAPI.GetJObjectAsync(lat, lon);
            return View(trails);
        }

        public async Task<IActionResult> Details(int id)
        {
            Trail trail = await BackendAPI.GetObjectByID(id);
            return View(trail);

        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}