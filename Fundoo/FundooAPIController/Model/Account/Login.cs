using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Account
{
    public class Login
    {
        private int id;
        private string name;
        [Key]
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
