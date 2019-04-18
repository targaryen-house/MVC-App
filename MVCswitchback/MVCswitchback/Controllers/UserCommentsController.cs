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
    public class UserCommentsController : Controller
    {
        private readonly SwitchbackDbContext _context;

        public UserCommentsController(SwitchbackDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.UserComments.ToListAsync());
        }

        /// <summary>
        /// Details of the user reviews
        /// </summary>
        /// <param name="id"> the idea of UserReviews </param>
        /// <returns> information of reviews </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userReview = await _context.UserComments
                    .FirstOrDefaultAsync(m => m.ID == id);
            if (userReview == null)
            {
                return NotFound();
            }
            return View(userReview);
        }

        /// <summary>
        /// Directs to creation page
        /// </summary>
        /// <returns> the creation view</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new user review
        /// </summary>
        /// <param name="userComments"></param>
        /// <returns> created review </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(" ID, UserID, TrailID, UserComment")] UserComments userComments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userComments);
        }

        /// <summary>
        /// directs to edit page to edit reveiws 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> edit view </returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userReview = await _context.UserComments.FindAsync(id);
            if (userReview == null)
            {
                return NotFound();
            }
            return View(userReview);
        }

        /// <summary>
        /// Edits a user review 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userComments"></param>
        /// <returns> edited review</returns>
        public async Task<IActionResult> Edit(int id, [Bind(" ID, UserID, TrailID, UserComment")] UserComments userComments)
        {
            if (id != userComments.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserReviewExists(userComments.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userComments);
        }


        /// <summary>
        /// Directs to delete page
        /// </summary>
        /// <param name="id"></param>
        /// <returns> delete view </returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userReview = await _context.UserComments
                .FirstOrDefaultAsync(m => m.ID == id);

            if (userReview == null)
            {
                return NotFound();
            }
            return View(userReview);
        }

        /// <summary>
        /// Deletes and confirms a review
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deletion confirmation </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var userReview = await _context.UserComments.FindAsync(id);
            _context.UserComments.Remove(userReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserReviewExists(int id)
        {
            return _context.UserComments.Any(e => e.ID == id);
        }
    }
}
