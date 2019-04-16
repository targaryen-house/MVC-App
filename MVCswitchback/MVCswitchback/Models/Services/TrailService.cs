using Microsoft.AspNetCore.Mvc;
using MVCswitchback.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models
{
    public class TrailService : ITrail
    {
        private Rootobject _trail;
        public TrailService(Rootobject trail)
        {
            _trail = trail;
        }
        public Task CreateTrail(Trail trail)
        {
            throw new NotImplementedException();
        }

        public Task<Trail> DeleteTrail(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditTrail(int id, [Bind(new[] { "" })] Trail trail)
        {
            throw new NotImplementedException();
        }

        public async Task<Trail> GetTrail(int id)
        {
            return _trail.Trails.FirstOrDefault(i => i.ID == id);
        }

        public bool HotelExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
