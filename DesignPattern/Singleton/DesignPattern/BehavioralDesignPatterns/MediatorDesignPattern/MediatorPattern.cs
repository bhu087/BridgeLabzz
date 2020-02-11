////------------------------------------------------------------------------
////<copyright file="MediatorPattern.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.MediatorDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// This is Mediator for Chat room
    /// </summary>
    public class MediatorPattern
    {
        /// <summary>
        /// Mediators this instance.
        /// </summary>
        public static void Mediator()
        {
            ////User user1 = new User("Manmohan");
            ////user1.DisplayMessage("Im Manmohan Here, good morning");
            ////Thread.Sleep(1000);
            ////User user2 = new User("Dawan");
            ////user2.DisplayMessage("says good morning");
            ////Thread.Sleep(1000);
            ////User user3 = new User("Bhuwan");
            ////user3.DisplayMessage("How are you all");
            ////Thread.Sleep(1000);
            ////User user4 = new User("Savan");
            ////user4.DisplayMessage("thank you for Chat!!!");
            User user = new User
            {
                Name = Console.ReadLine(),
                Message = Console.ReadLine()
            };
            user.DisplayMessage();
            Console.WriteLine("Do you want to Continue Y/N");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Mediator();
            }

            ChatRoom chatRoom = new ChatRoom();
            Console.Clear();
            chatRoom.ChatHistory();
        }
    }
}
