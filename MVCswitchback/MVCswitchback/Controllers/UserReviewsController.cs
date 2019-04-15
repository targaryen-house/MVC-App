using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCswitchback.Data;
using MVCswitchback.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCswitchback.Controllers
{
    public class UserReviewsController : Controller
    {
        private readonly SwitchbackDbContext _context;

        public UserReviewsController(SwitchbackDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.UserReviews.ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userReview = await _context.UserReviews
                    .FirstOrDefaultAsync(m => m.ID == id);
            if (userReview == null)
            {
                return NotFound();
            }
            return View(userReview);
        }

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userReview"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(" ID, UserID, TrailID, UserComment")] UserReviews userReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userReview);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userReview = await _context.UserReviews.FindAsync(id);
            if (userReview == null)
            {
                return NotFound();
            }
            return View(userReview);
        }
    }
}
