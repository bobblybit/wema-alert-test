using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Data
{
    public class StateAndLGA
    {
        public bool CheckState(string state)
        {
            IDictionary<string, List<string>> StatesAndLGA = new Dictionary<string, List<string>>();
            StatesAndLGA.Add("Abia", new List<string> {
                "Aba North",
                "Aba South"
            });

            foreach (var item in StatesAndLGA)
            {
                if (item.Key == state)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
