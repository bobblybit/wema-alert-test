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
            return Ok(Utilities.CreateResponse("Phone Was Successfully with token", ModelState, ""));
        }
    }
}
