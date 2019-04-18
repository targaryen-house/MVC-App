using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models
{
    public class UserReviews
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TrailID { get; set; }
        public string UserComment { get; set; }
    }
}
