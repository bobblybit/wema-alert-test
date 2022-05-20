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
        public async Task<IActionResult> AddCustomer([FromBody] CustomerToAddDto customer)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model error", "Model state not valid");
                return BadRequest(Utilities.CreateResponse<string>("Model error", ModelState, ""));
            }

            var response = StateAndLGA.Check(customer.StateOfResidence, customer.LGA);

            if (!response.Status)
            {
                ModelState.AddModelError("Model error", response.message);
                return BadRequest(Utilities.CreateResponse<string>("Model error", ModelState, ""));
            }

            var customerToAdd = _mapper.Map<AppUser>(model);

            return Ok();
        }
    }
}
