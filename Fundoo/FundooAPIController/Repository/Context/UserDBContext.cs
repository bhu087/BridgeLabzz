using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository.Context
{
    class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
