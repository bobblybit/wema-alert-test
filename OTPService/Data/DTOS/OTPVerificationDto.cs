using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Data.DTOS
{
    public class OTPVerificationDto
    {
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
