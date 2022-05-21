using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Data
{
    public class PhoneNumberOTP
    {
        public string Id { get; set; }
        public string Phone { get; set; }
        public string OTPCode { get; set; }

        public PhoneNumberOTP()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
