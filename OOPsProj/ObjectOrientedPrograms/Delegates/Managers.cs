
namespace ObjectOrientedPrograms.Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Managers
    {
        public void ManagerList(string person)
        {
            List<User> users = new List<User>();
            users.Add(new User() { name = "Balu" });
            users.Add(new User() { name = "subbu" });
            users.Add(new User() { name = "Rahul" });
            users.Add(new User() { name = "Nayan" });
            Console.WriteLine("--------------------Managers---------------------");
            foreach (User user in users)
            {
                user.GetMessage(person);
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
