using BankService.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        [HttpGet("get-banks")]
        public async Task<IActionResult> GetBank()
        {
            var response= await _bankService.GetBanks();

            return Ok(response);
        }
    }
}
