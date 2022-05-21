using Microsoft.EntityFrameworkCore;
using OTPService.Data;
using OTPService.DataBase;
using OTPService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Repository.Implementation
{
    public class OTPRepositoy : IOTPRepositoy
    {
        private readonly OTPContext _ctx;
        public OTPRepositoy(OTPContext ctx)
        {
            _ctx = ctx;
        }
        public Task<bool> CheckPhoneNumeber(string Phone)
        {
            return Task.Run(() => _ctx.Tbl_Verification.Any(x => x.Phone == Phone));
        }

        public async Task<PhoneNumberOTP> GetByNumber(string Phone)
        {
            return await _ctx.Tbl_Verification.FirstOrDefaultAsync(x => x.Phone == Phone);
        }

        public async Task<bool> SaveOTP(PhoneNumberOTP PhoneNumber)
        {
            _ctx.Tbl_Verification.Add(PhoneNumber);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(PhoneNumberOTP Phone)
        {
            _ctx.Update(Phone);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
