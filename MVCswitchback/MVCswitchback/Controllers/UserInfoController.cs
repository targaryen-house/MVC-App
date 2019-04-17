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
    public class UserInfoController : Controller
    {
        private readonly SwitchbackDbContext _context;

        public UserInfoController(SwitchbackDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.UserInfo.ToListAsync());
        }

        /// <summary>
        /// Details of the user information
        /// </summary>
        /// <param name="id"> the idea of UserInfo </param>
        /// <returns> information of selected user </returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userInfo = await _context.UserInfo
                    .FirstOrDefaultAsync(m => m.ID == id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return View(userInfo);
        }

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates new user information
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns> new user that was created </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(" ID, UserName, FirstName, LastName")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

        /// <summary>
        /// redirects to editor of selected user
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Edit page </returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return View(userInfo);
        }

        /// <summary>
        /// Edits user information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userInfo"></param>
        /// <returns> edited user info </returns>
        public async Task<IActionResult> Edit(int id, [Bind(" ID, UserName, FirstName, LastName")] UserInfo userInfo)
        {
            if (id != userInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInfoExists(userInfo.ID))
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
            return View(userInfo);
        }

         /// <summary>
         /// Directs to delete page
         /// </summary>
         /// <param name="id"></param>
         /// <returns> delete confirmation </returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .FirstOrDefaultAsync(m => m.ID == id);

            if (userInfo == null)
            {
                return NotFound();
            }
            return View(userInfo);
        }

        /// <summary>
        /// Deletes a specified user
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Confirmed deletion </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var userInfo = await _context.UserInfo.FindAsync(id);
            _context.UserInfo.Remove(userInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool UserInfoExists(int id)
        {
            return _context.UserInfo.Any(e => e.ID == id);
        }
    }
}
