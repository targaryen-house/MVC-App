using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCswitchback.Models;
using MVCswitchback.Data;

namespace MVCswitchback.Controllers
{
    public class PartialViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCommentView()
        {
            return PartialView("_CommentsPartialView");
        }
    }
}
