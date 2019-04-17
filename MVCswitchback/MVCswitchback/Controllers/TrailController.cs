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

        /// <summary>
        /// Displays details of Trails
        /// </summary>
        /// <param name="id"> the id of the trail </param>
        /// <returns> the details of a chose trail </returns>
        public async Task<IActionResult> Details(int id)
        {
            Trail trail = await BackendAPI.GetTrailByID(id);
            return View(trail);

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
        public async Task<IActionResult> Create([Bind("")] Trail trail)
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