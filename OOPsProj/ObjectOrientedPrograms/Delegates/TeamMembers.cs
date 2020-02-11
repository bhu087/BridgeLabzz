////------------------------------------------------------------
////<copyright file="TeamMembers.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////------------------------------------------------------------
namespace ObjectOrientedPrograms.Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Team members class
    /// </summary>
    public class TeamMembers
    {
        /// <summary>
        /// Teams the members list.
        /// </summary>
        /// <param name="person">The person.</param>
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
