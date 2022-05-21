using Microsoft.EntityFrameworkCore;
using OTPService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.DataBase
{
    public class OTPContext : DbContext
    {
        public OTPContext(DbContextOptions<OTPContext> options) : base(options)
        {

        }
        public DbSet<PhoneNumberOTP> Tbl_Verification { get; set; }
    }
}
