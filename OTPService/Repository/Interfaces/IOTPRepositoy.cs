using OTPService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Repository.Interfaces
{
    public interface IOTPRepositoy
    {
        Task<bool> SaveOTP(PhoneNumberOTP PhoneNumber);
        Task<bool> CheckPhoneNumeber(string Phone);

        Task<bool> Update(PhoneNumberOTP Phone);

        Task<PhoneNumberOTP> GetByNumber(string Phone);

    }
}
