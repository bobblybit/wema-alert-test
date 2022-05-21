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

        [HttpPost("verify-phone-number")]
        public async Task<IActionResult> VerifyPhoneNumber([FromBody] OTPVerificationDto model)
        {

            if (!await _oTPService.VerifyPhoneNumber(model.Phone, model.Code))
            {
                return Ok(Utilities.CreateResponse("This Provided Phone number does not match token", ModelState, ""));

            }
            return Ok(Utilities.CreateResponse("Phone number Was Successfully verified with token", ModelState, ""));
        }

        [HttpPost("send-phone-OTP")]
        public async Task<IActionResult> SendOTP([FromBody] SendOTPDto model)
        {

            if (String.IsNullOrEmpty(model.PhoneNumber))
            {
                ModelState.AddModelError("Model error", "Phone Number Cannot be Empty");
                return BadRequest(Utilities.CreateResponse<string>("Model error", ModelState, ""));
            }

            if (!await _oTPService.SendOTP(model.PhoneNumber))
            {
                return Ok(Utilities.CreateResponse("This Provided Phone number Does not exist", ModelState, ""));

            }
            return Ok(Utilities.CreateResponse("Token was successfully sent to phone number ", ModelState, ""));
        }
    }
}
