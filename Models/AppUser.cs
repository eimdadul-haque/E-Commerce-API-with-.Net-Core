using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

    }
}
