using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models
{
    public class UserComments
    {
        public int ID { get; set; }
        public int UserInfoID { get; set; }
        public int TrailID { get; set; }
        public string UserComment { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
