using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models.Interfaces
{
    public interface ITrailManager
    {
        // Get all User Reviews for a given trail by trail ID
        Task<List<UserComments>> GetUserReviews(int id);
        SelectList GetAllUsers();
        Task AddComment(UserComments userComment);
    }
}
