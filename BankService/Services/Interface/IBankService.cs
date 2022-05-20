using BankService.Data.DTOS;
using BankService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Services.Interface
{
    public interface IBankService
    {
        Task<BankToReturnDto> GetBanks();
    }
}
