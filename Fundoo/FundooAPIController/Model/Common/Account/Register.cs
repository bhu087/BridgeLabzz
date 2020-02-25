using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Common.Account
{
    public class Register
    {
        [Required]
        private int id;
        [Required]
        private string name;
        [Required]
        private string email;
        [Required]
        private string password;
        [Required]
        private string mobile;
        [Required]
        private string city;
        private string salary;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Mobile { get => mobile; set => mobile = value; }
        public string City { get => city; set => city = value; }
        public string Salary { get => salary; set => salary = value; }
    }
}
