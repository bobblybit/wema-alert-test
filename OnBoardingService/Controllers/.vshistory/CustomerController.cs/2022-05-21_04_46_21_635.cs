using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnBoardingService.Commons;
using OnBoardingService.Data;
using OnBoardingService.Data.DTOS;
using OnBoardingService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CustomerController(UserManager<AppUser> userManager, IMapper mapper, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _mapper = mapper;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerToAddDto customerToAdd )
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model error", "Model state not valid");
                return BadRequest(Utilities.CreateResponse<string>("Model error", ModelState, ""));
            }

            var response = StateAndLGA.Check(customerToAdd.StateOfResidence, customerToAdd.LGA, _env);

            if (!response.Status)
            {
                ModelState.AddModelError("Model error", response.message);
                return BadRequest(Utilities.CreateResponse<string>("Model error", ModelState, ""));
            }

            var customer  = _mapper.Map<AppUser>(customerToAdd);
            customer.UserName = customerToAdd.Email;
            var managerResponse = await _userManager.CreateAsync(customer, customer.Password);

            if (!managerResponse.Succeeded)
            {
                foreach (var error in managerResponse.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(Utilities.CreateResponse<string>("", ModelState, ""));
            }

            CustomerToReturn customerToReturn = _mapper.Map<CustomerToReturn>(customer);

            return Ok(Utilities.CreateResponse("Customer Was onboarded Successfully", ModelState, customerToReturn));
        }
    }
}
