using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnBoardingService.Data.DTOS;
using OnBoardingService.Data.Models;
using OnBoardingService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CustomerService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;

        }

        public async Task<IdentityResult> AddCustomer(AppUser customerToAdd)
        {
            return await _userManager.CreateAsync(customerToAdd, customerToAdd.Password);
        }

        public List<CustomerToReturn> GetAllCustomers()
        {
            var users = _userManager.Users.ToList();
            if(users == null)
            {
                return null;
            }

            var result = new List<CustomerToReturn>(); 
            foreach (var user in users)
            {
                result.Add(new CustomerToReturn
                {
                    Email = user.Email,
                    LGA = user.LGA,
                    PhoneNumber = user.PhoneNumber,
                    StateOfResidence = user.StateOfResidence
                });
            }
            return result;
        }
    }
}
