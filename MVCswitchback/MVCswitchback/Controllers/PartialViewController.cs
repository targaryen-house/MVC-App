//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MVCswitchback.Models;
//using MVCswitchback.Data;
//using Microsoft.EntityFrameworkCore;

//namespace MVCswitchback.Controllers
//{
//    public class PartialViewController : Controller
//    {
//        private readonly SwitchbackDbContext _context;

//        public PartialViewController(SwitchbackDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> Index(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            var comments = await _context.UserReviews
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (comments == null)
//            {
//                return NotFound();
//            }
//            return PartialView(comments);
//        }

//        public async Task<IActionResult> GetCommentView(int? id)
//        {
//            //TODO
//            //Get user id
//            if (id == null)
//            {
//                return NotFound();
//            }
//            var comments = await _context.UserReviews
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (comments == null)
//            {
//                return NotFound();
//            }
//            return PartialView(comments);
//            //get trail id

//            //get user comments specific to the trail.

//            //return PartialView("_CommentsPartialView");

//        }
//    }
//}
