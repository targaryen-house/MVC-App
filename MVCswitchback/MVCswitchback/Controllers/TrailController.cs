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


        public async Task<IActionResult> Index(string SearchString)
        {
            Rootobject trails = await BackendAPI.GetJObjectAsync(SearchString);
            return View(trails);
        }

        public IActionResult Details()
        {
            return View();
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