using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms.Delegates
{
    class TeamLeads
    {
        public void TeamLeadsList(string person)
        {
            List<User> users = new List<User>();
            users.Add(new User() { name = "Bavya" });
            users.Add(new User() { name = "Divya" });
            users.Add(new User() { name = "Ramya" });
            users.Add(new User() { name = "Janya" });
            Console.WriteLine("--------------------TeamLeads---------------------");
            foreach (User user in users)
            {
                user.GetMessage(person);
            }
            Console.WriteLine("---------------------------------------------------");
        }
    }
}
