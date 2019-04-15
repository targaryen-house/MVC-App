using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCswitchback.Data;

namespace MVCswitchback.Controllers
{
    public class UserReviewsController : Controller
    {
        private readonly SwitchbackDbContext _context;

        

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}
