﻿/////------------------------------------------------------------------------
////<copyright file="Employee.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// this is the employee model
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The user identifier
        /// </summary>
        private string userId;

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The mobile
        /// </summary>
        private string mobile;

        /// <summary>
        /// The salary
        /// </summary>
        private string salary;

        /// <summary>
        /// The city
        /// </summary>
        private string city;
        public string UserId { get => this.userId; set => this.userId = value; }
        [Required(ErrorMessage ="Name Required")]
        public string Name { get => this.name; set => this.name = value; }
        [Required(ErrorMessage ="Mobile Number Required")]
        public string Mobile { get => this.mobile; set => this.mobile = value; }
        public string Salary { get => this.salary; set => this.salary = value; }
        [Required(ErrorMessage ="City name Required")]
        public string City { get => this.city; set => this.city = value; }
    }
}
