﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Data.DTOS
{
    public class UserToAddDto
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string StateOfResidence { get; set; }
        [Required]
        public string LGA { get; set; }
    }
}
