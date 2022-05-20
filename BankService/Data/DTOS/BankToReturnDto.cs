using BankService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Data.DTOS
{
    public class BankToReturnDto
    {
        public List<Bank> Result { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorMessages { get; set; }

        public bool HasError { get; set; }

        public string TimeGenerated { get; set; }

        public BankToReturnDto()
        {
            Result = new List<Bank>();
        }

    }
}
