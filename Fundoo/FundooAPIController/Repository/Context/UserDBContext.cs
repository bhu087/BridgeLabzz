using Microsoft.EntityFrameworkCore;
using Model.Account;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DbSet<Registration> Registers
        {
            get; set;
        }
        public DbSet<NotesModel> Notes
        {
            get; set;
        }
        public DbSet<LabelModel> Lables
        {
            get; set;
        }
    }
}
