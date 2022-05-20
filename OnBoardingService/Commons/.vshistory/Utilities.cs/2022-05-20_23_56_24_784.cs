﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnBoardingService.Data.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Commons
{
    public class Utilities
    {

        public static string ChangeToTitleCase(string str)
        {
            var covertedString = str.ToCharArray()[0].ToString().ToUpper() + str.Substring(1);
            return covertedString;
        }
        public static ResponseDto<T> CreateResponse<T>(string message, ModelStateDictionary errs, T data)
        {
            var errors = new Dictionary<string, string>();
            if (errs != null)
            {
                foreach (var err in errs)
                {
                    var counter = 0;
                    var key = err.Key;
                    var errVals = err.Value;
                    foreach (var errMsg in errVals.Errors)
                    {
                        errors.Add($"{(counter + 1)} - {key}", errMsg.ErrorMessage);
                        counter++;
                    }
                }
            }

            var obj = new ResponseDto<T>()
            {
                Message = message,
                Errors = errors,
                Data = data
            };
            return obj;
        }

    }
}
