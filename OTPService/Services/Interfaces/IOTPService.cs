using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Services.Interfaces
{
    public interface IOTPService
    {
        Task<bool> VerifyPhoneNumber(string phoneNumber, string code);
        Task<bool> SendOTP(string Number);
    }
}
