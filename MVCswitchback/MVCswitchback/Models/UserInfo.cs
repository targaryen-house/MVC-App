using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models
{
    public class UserInfo
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "User Name:")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        public ICollection<UserComments> UserComments { get; set; }
    }
}
