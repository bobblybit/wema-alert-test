using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Data.DTOS
{
    public class CustomerToReturn
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StateOfResidence { get; set; }
        public string LGA { get; set; }
    }
}
