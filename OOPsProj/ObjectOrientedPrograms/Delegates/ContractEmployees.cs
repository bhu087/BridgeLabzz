////------------------------------------------------------------
////<copyright file="ContractEmployees.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////------------------------------------------------------------
namespace ObjectOrientedPrograms.Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Contract employees list
    /// </summary>
    public class ContractEmployees
    {
        /// <summary>
        /// Contracts the employees list.
        /// </summary>
        /// <param name="person">The person.</param>
        public void ContractEmployeesList(string person)
        {
            List<User> users = new List<User>();
            users.Add(new User() { name = "Kavan" });
            users.Add(new User() { name = "Bhuvan" });
            users.Add(new User() { name = "Jagan" });
            users.Add(new User() { name = "John" });
            Console.WriteLine("----------------Contract Employees-----------------");
            foreach (User user in users)
            {
                user.GetMessage(person);
            }

            Console.WriteLine("----------------------------------------------------");
        }
    }
}
