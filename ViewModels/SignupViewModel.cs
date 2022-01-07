using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.ViewModels
{
    public class SignupViewModel
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        [Compare("password")]
        public string confirmPassword { get; set; }


    }
}
