using OTPService.Data;
using OTPService.Repository.Interfaces;
using OTPService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Services.Implementation
{
    public class OTPClient : IOTPService
    {
        private readonly IOTPRepositoy _OTPRespository;

        static Random generator = new Random();
        public OTPClient(IOTPRepositoy OTPRespository)
        {
            _OTPRespository = OTPRespository;
        }

        public async Task<bool> SendOTP(string Number)
        {

            // get phone number by Id
            var phone = await _OTPRespository.GetByNumber(Number);
            if (phone == null)
                return false;

            string OTP = generator.Next(100, 500).ToString();

            phone.OTPCode = OTP;

            return await _OTPRespository.Update(phone);
        }

        public async Task<bool> VerifyPhoneNumber(string phoneNumber, string code)
        {

            var phone = await _OTPRespository.GetByNumber(phoneNumber);
            if (phone == null)
                return false;

            if (phone.OTPCode == code)
            {
                return true;
            }

            return false;

        }
    }
}
