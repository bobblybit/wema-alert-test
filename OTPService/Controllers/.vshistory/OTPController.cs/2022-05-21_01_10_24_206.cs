using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public OTPController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> VerifyPhoneNumber()
        {
            return Ok();
        }
    }
}
