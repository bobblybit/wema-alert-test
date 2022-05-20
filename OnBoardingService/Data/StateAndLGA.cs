using OnBoardingService.Commons;
using OnBoardingService.Data.DTOS;
using OnBoardingService.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnBoardingService.Data
{
    public class StateAndLGA
    {
        public static StateResponse Check(string state, string lga)
        {
            StateResponse response = new StateResponse();

            var path = Path.GetFullPath(@"./Data/StatesAndLGA.json");
            var jsondata = File.ReadAllText(path);
            var output = JsonSerializer.Deserialize<List<StatesAndLga>>(jsondata, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            lga = Utilities.ChangeToTitleCase(lga);

            //TODO :CONVERT TO TITLE CASE

            foreach (var item in output)
            {
                if (item.Alias == state.ToLower())
                {
                    if (item.lgas.Contains(lga))
                    {
                        response.Status = true;
                        response.message = "State is found";
                        return response;
                    }

                }
            }

            response.Status = false;
            response.message = "State Does not exist or LGA does not match state";
            return response;
        }


    }
}
