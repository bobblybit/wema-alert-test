using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CustomerController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerToAddDto customerToAdd )
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model error", "Model state not valid");
                return BadRequest(Utilities.CreateResponse<string>("Model error", ModelState, ""));
            }

            var response = StateAndLGA.Check(customerToAdd.StateOfResidence, customerToAdd.LGA);

            if (!response.Status)
            {
                ModelState.AddModelError("Model error", response.message);
                return BadRequest(Utilities.CreateResponse<string>("Model error", ModelState, ""));
            }

            var customer  = _mapper.Map<AppUser>(customerToAdd);
            var managerResponse = await _userManager.CreateAsync(customer, customer.Password);

            if (!managerResponse.Succeeded)
            {
                foreach (var error in managerResponse.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(Utilities.CreateResponse<string>("", ModelState, ""));
            }

            return Ok(Utilities.CreateResponse("Customer Was onboarded Successfully", ModelState, articleToReturn));
        }
    }
}
