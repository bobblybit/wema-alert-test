using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Data.DTOS
{
    public class SendOTPDto
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
