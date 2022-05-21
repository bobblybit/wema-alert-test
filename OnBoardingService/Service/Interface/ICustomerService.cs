using Microsoft.AspNetCore.Identity;
using OnBoardingService.Data.DTOS;
using OnBoardingService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Repository
{
   public interface ICustomerService
    {
        Task<IdentityResult> AddCustomer(AppUser customer);
        List<CustomerToReturn> GetAllCustomers();
    }
}
