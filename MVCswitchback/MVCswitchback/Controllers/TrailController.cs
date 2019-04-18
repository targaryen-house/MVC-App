using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using MVCswitchback.Models;
using MVCswitchback.Models.Interfaces;
using MVCswitchback.Models.ViewModels;
using Newtonsoft.Json;


namespace MVCswitchback.Controllers
{
    public class TrailController : Controller
    {
        private readonly ITrailManager _trail;
        private readonly IConfiguration _configuration;

        public TrailController(ITrailManager trail, IConfiguration configuration)
        {
            _trail = trail;
            _configuration = configuration;
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
        /// <returns> the details of a chose trail </returns>
        public async Task<IActionResult> Details(int id)
        {
            Trail trail = await BackendAPI.GetTrailByID(id);
            var userReviews = await _trail.GetUserReviews(id);
            Weather weather = await BackendAPI.GetWeather(trail.Latitude, trail.Longitude, _configuration);

            TrailDetails trailDetails = new TrailDetails()
            {
                Trail = trail,
                UserComments = userReviews,
                Weather = weather
            };

            return View(trailDetails);
        }

        /// <summary>
        /// directs to the creation of a new trail
        /// </summary>
        /// <returns> the new trail on the list </returns>
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Summary, Difficulty, Location, ImgMedium, Length, Ascent, Descent, High, Low, Longitude, Latitude, ConditionStatus, ConditionDetails, ConditionDate")] Trail trail)
        {
            await BackendAPI.CreateTrailAsync(trail);
            Trail returnTrail = await BackendAPI.GetTrailByID(trail.ID);
            return View(returnTrail);
        }

        /// <summary>
        /// Edits the selected trail
        /// </summary>
        /// <param name="trail"> declaration of trail </param>
        /// <returns> the edited trail </returns>
        public async Task<IActionResult> Edit(Trail trail)
        {
            Trail returnTrail = await BackendAPI.UpdateTrailAsync(trail);
            return View(returnTrail);
        }

        /// <summary>
        /// Deletes selected trail
        /// </summary>
        /// <returns> deletion confirmation </returns>
        public async Task<IActionResult> Delete(int id)
        {
            var status =  await BackendAPI.DeleteTrailAsync(id);
            return View(status);
        }
    }
}