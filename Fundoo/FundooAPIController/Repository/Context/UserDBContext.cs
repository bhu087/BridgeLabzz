using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model.Common.Account;

namespace Repository.Context
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }
        public DbSet<Login> Logins
        {
            get; set;
        }
        public DbSet<Register> Registers
        {
            get; set;
        }
    }
}
