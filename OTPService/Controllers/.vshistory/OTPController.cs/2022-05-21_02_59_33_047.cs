using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            if (String.IsNullOrEmpty(model.Phone) || String.IsNullOrEmpty(model.Code))
            {
                return BadRequest();
            }

            if (!await _oTPService.VerifyPhoneNumber(model.Phone, model.Code))
            {

            }

            return Ok();
        }
    }
}
