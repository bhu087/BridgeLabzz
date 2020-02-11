using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.MediatorDesignPattern
{
    public class User
    {
        private string name;
        IChatRoom chatRoom;
        public User()
        {

        }
        public User(string name)
        {
            this.name = name;
        }
        public string Name { get { return name; } set { this.name = value; } }
        public string Message { get; set; }
        public void DisplayMessage()
        {
            chatRoom = new ChatRoom();
            chatRoom.ShowMessage(this,Message);
        }
    }
}
