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
        
        public async Task<IActionResult> Index(string searchString)
        {
            List<Trail> trails = await BackendAPI.GetTrailsAsync(searchString);
            TrailsRootVM trailList = new TrailsRootVM
            {
                Trails = trails
            };
            return View(trailList);
            
        }

        /// <summary>
        /// Displays details of Trails
        /// </summary>
        /// <param name="id"> the id of the trail </param>
        /// <returns> returns the details of a chosen trail </returns>
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

        /// <summary>
        /// Directs to the creation of a new trail
        /// </summary>
        /// <returns> Returns the view to create a new trail </returns>
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("")] Trail trail)
        {
            await BackendAPI.CreateTrailAsync(trail);
            Trail returnTrail = await BackendAPI.GetTrailByID(trail.ID);
            return View(returnTrail);
        }

        /// <summary>
        /// Edits the a selected trail
        /// </summary>
        /// <param name="trail"> id of the trail </param>
        /// <returns> Returns the Edited trail </returns>
        public async Task<IActionResult> Edit(Trail trail)
        {
            Trail returnTrail = await BackendAPI.UpdateTrailAsync(trail);
            return View(returnTrail);
        }

        /// <summary>
        /// Deletes a selected trail
        /// </summary>
        /// <returns> Returns deletion confirmation </returns>
        public async Task<IActionResult> Delete(int id)
        {
            var status =  await BackendAPI.DeleteTrailAsync(id);
            return View(status);
        }
    }
}