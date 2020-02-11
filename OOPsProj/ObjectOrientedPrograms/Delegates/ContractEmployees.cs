using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms.Delegates
{
    class ContractEmployees
    {
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
