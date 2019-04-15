﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserReviews> UserReviews { get; set; }
    }
}