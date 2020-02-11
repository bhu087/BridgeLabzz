using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms.Delegates
{
    class TeamMembers
    {
        public void TeamMembersList(string person)
        {
            List<User> users = new List<User>();
            users.Add(new User() { name = "Manju" });
            users.Add(new User() { name = "Sanju" });
            users.Add(new User() { name = "Ranju" });
            users.Add(new User() { name = "Anju" });
            Console.WriteLine("--------------------Team Members---------------------");
            foreach (User user in users)
            {
                user.GetMessage(person);
            }
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
