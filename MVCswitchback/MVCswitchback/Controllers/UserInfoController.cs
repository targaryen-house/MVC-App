using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCswitchback.Data;
using MVCswitchback.Models;
using Microsoft.EntityFrameworkCore;
using MVCswitchback.Models.Interfaces;

namespace MVCswitchback.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserInfoManager _users;

        public UserInfoController(IUserInfoManager users)
        {
            _users = users;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            List<UserInfo> users = await _users.GetAllUsers(searchString);

            return View(users);
        }

        /// <summary>
        /// Details of the user information
        /// </summary>
        /// <param name="id"> the id of UserInfo </param>
        /// <returns> information of selected user </returns>
        public async Task<IActionResult> Details(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var user = await _users.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Directs to the creation page
        /// </summary>
        /// <returns>the creation view</returns>
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
                await _users.AddUser(userInfo);
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

        /// <summary>
        /// redirects to editor of selected user
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Edit page </returns>
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var user = await _users.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
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
                    await _users.UpdateUser(userInfo);
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
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var user = await _users.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
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
            var user = await _users.GetUser(id);

            if (user != null)
            {
                _users.DeleteUser(user);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(int id)
        {
            return _users.UserExists(id);
        }
    }
}
