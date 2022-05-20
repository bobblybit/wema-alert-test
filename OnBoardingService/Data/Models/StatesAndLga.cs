using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Data.Models
{
    public class StatesAndLga
    {
        public string State { get; set; }
        public string Alias { get; set; }
        public List<string> lgas { get; set; }

        public StatesAndLga()
        {
            lgas = new List<string>();
        }
    }
}
