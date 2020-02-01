
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using System.Threading;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class StockAccountProcess
    {
        public static void UserAccount()
        {
            Utility stockUtility = new Utility();
            UserObject userObject = new UserObject()
            {
                Name = Console.ReadLine(),
                SharesList = string.Empty,
                ShareMoney = 0,
                DateTimes = 0,
                Status = 0
            };
            MyLinkedList<UserObject> userList = new MyLinkedList<UserObject>();
            userList.Add(userObject);
            string output = JsonConvert.SerializeObject(userList,Formatting.Indented);
            File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json", output);
        }
    }
}
