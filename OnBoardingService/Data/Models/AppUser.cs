using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Data.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string StateOfResidence { get; set; }
        [Required]
        public string LGA { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
