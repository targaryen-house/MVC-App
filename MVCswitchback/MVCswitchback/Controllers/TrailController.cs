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
using MVCswitchback.Models.ViewModels;
using Newtonsoft.Json;


namespace MVCswitchback.Controllers
{
    public class TrailController : Controller
    {
        private readonly ITrailManager _trail;

        public TrailController(ITrailManager trail)
        {
            _trail = trail;
        }

        public async Task<IActionResult> Index(float lat, float lon)
        {
            Rootobject trails = await BackendAPI.GetTrailsAsync(lat, lon);
            return View(trails);
        }

        public async Task<IActionResult> Details(int id)
        {
            Trail trail = await BackendAPI.GetTrailByID(id);
            var userReviews = await _trail.GetUserReviews(id);
            Weather weather = await BackendAPI.GetWeather(trail.Latitude, trail.Longitude);

            TrailDetails trailDetails = new TrailDetails()
            {
                Trail = trail,
                UserReviews = userReviews,
                Weather = weather
            };

            return View(trailDetails);
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