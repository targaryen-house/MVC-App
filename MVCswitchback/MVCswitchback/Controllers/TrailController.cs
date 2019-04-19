using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        /// <returns> returns the details of a chosen trail </returns>
        public async Task<IActionResult> Details(int id)
        {
            Trail trail = await BackendAPI.GetTrailByID(id);
            var userList = await _trail.GetAllUsers();
            var userReviews = await _trail.GetUserReviews(id);
            Weather weather = await BackendAPI.GetWeather(trail.Latitude, trail.Longitude, _configuration);
            List<SelectListItem> users = new List<SelectListItem>();

            foreach (var item in userList)
            {
                users.Add(new SelectListItem { Text = item.UserName, Value = item.ID.ToString() });
            };

            TrailDetails trailDetails = new TrailDetails()
            {
                Trail = trail,
                Users = users,
                UserComments = userReviews,
                Weather = weather
            };

            return View(trailDetails);
        }

        /// <summary>
        /// Directs to the creation of a new trail
        /// </summary>
        /// <returns> Returns the view to create a new trail </returns>
        [HttpGet]
        public IActionResult HiddenGem()
        {
            return View();
        }

        [HttpPost("comment")]
        public async Task<IActionResult> Create(TrailDetails trailDetails)
        {
            UserComments comment = new UserComments()
            {
                TrailID = trailDetails.Trail.TrailID,
                UserInfoID = trailDetails.UserComment.UserInfoID,
                UserComment = trailDetails.UserComment.UserComment,

            };

            int id = trailDetails.Trail.TrailID;
            await _trail.AddComment(comment);
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> HiddenGem([Bind("Name, Summary, Difficulty, Location, ImgMedium, Length, Ascent, Descent, High, Low, Longitude, Latitude, ConditionStatus, ConditionDetails, ConditionDate")] Trail trail)
        {
            await BackendAPI.CreateTrailAsync(trail);
            return RedirectToAction("ThankYou");
        }


        public IActionResult ThankYou()

        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int ID)
        //{
        //    Trail returnTrail = await BackendAPI.GetTrailByID(ID);
        //    return View(returnTrail);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit([Bind("TrailID, Name, Summary, Difficulty, Stars, Location, ImgMedium, Length, Ascent, Descent, High, Low, Longitude, Latitude, ConditionStatus, ConditionDetails, ConditionDate")]Trail trail)
        //{
        //    Trail returnTrail = await BackendAPI.UpdateTrailAsync(trail);
        //    return RedirectToAction();

        //}

        /// <summary>
        /// Deletes a selected trail
        /// </summary>
        /// <returns> Returns deletion confirmation </returns>
        public async Task<IActionResult> Delete(int id)
        {
            var status = await BackendAPI.DeleteTrailAsync(id);
            return View(status);
        }
    }
}