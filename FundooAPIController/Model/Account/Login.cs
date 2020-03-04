using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Account
{
    public class Login
    {
        private string email;
        private string password;
        [Key]
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
