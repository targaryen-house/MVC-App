using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCswitchback.Models;
using MVCswitchback.Data;
using Microsoft.EntityFrameworkCore;

namespace MVCswitchback.Controllers
{
    public class HomeController : Controller
    {
        private readonly SwitchbackDbContext _context;

        public HomeController(SwitchbackDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCommentView(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var comments = await _context.UserReviews
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comments == null)
            {
                return NotFound();
            }
            return PartialView(comments);
            //get trail id

            //get user comments specific to the trail.

            //return PartialView("_CommentsPartialView");

        }
    }
}
