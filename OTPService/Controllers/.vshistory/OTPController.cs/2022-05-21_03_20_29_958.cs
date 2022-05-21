using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTPService.Commons;
using OTPService.Data.DTOS;
using OTPService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly IOTPService _oTPService;
        public OTPController(IOTPService oTPService)
        {
            _oTPService = oTPService;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyPhoneNumber([FromBody] OTPVerificationDto model)
        {

            if (!await _oTPService.VerifyPhoneNumber(model.Phone, model.Code))
            {
                return Ok(Utilities.CreateResponse("This Provided Phone number does not match token", ModelState, ""));

            }
            return Ok(Utilities.CreateResponse("Phone number Was Successfully verified with token", ModelState, ""));
        }

        [HttpPost]
        public async Task<IActionResult> SendOTP([FromBody] string PhoneNumber)
        {

            if (String.IsNullOrEmpty(PhoneNumber))
            {
                ModelState.AddModelError("Model error", "Phone Number Cannot be Empty");
                return BadRequest(Utilities.CreateResponse<string>("Model error", ModelState, ""));
            }

            if (!await _oTPService.SendOTP(PhoneNumber))
            {
                return Ok(Utilities.CreateResponse("This Provided Phone number Does not exist", ModelState, ""));

            }
            return Ok(Utilities.CreateResponse("Phone Was Successfully with token", ModelState, ""));
        }
    }
}
