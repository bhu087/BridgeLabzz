using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.MediatorDesignPattern
{
    class ChatRoom
    {
        public static void ShowMessage(User user, string message)
        {
            DateTime dateTime = new DateTime();
            Console.WriteLine(dateTime);
            Console.WriteLine(user.name +" : "+message);
        }
    }
}
