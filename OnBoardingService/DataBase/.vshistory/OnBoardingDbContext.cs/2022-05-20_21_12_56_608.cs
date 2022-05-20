using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnBoardingService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.DataBase
{
    public class OnBoardingDbContext : IdentityDbContext<AppUser>
    {
        public OnBoardingDbContext(DbContextOptions<OnBoardingDbContext> options) : base(options) { }
        {

        }
    }
}
