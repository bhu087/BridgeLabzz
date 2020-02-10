using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.MediatorDesignPattern
{
    class MediatorPattern
    {
        public void Mediator()
        {
            User user1 = new User("Manmohan");
            user1.DisplayMessage("Im Manmohan Here, good morning");
            User user2 = new User("Dawan");
            user2.DisplayMessage("says good morning");
            User user3 = new User("Bhuwan");
            user3.DisplayMessage("How are you all");
            User user4 = new User("Savan");
            user4.DisplayMessage("thank you for Chat!!!");
        }
    }
}
