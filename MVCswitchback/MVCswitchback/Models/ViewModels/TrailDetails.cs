using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models.ViewModels
{
    public class TrailDetails
    {
        public Trail Trail { get; set; }
        public List<UserComments> UserComments { get; set; }
        public Weather Weather { get; set; }
    }
}
