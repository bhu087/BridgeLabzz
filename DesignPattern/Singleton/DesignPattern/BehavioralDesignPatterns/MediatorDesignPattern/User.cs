using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.MediatorDesignPattern
{
    class User
    {
        public string name 
        { 
            get { return this.name; } 
            set { this.name = name; }
        }
        public User(string name)
        {
            this.name = name;
        }
        public void DisplayMessage(string message)
        {
            ChatRoom.ShowMessage(this,message);
        }
    }
}
