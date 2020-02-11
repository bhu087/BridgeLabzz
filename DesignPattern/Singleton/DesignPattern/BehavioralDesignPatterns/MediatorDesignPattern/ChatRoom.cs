////------------------------------------------------------------------------
////<copyright file="ChatRoom.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.MediatorDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Chat room
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPatterns.MediatorDesignPattern.IChatRoom" />
    public class ChatRoom : IChatRoom
    {
        /// <summary>
        /// The chat room messages
        /// </summary>
        private static List<User> chatRoomMessages = new List<User>();

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="message">The message.</param>
        public void ShowMessage(User user, string message)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("[" + dateTime + "]");
            Console.WriteLine(user.Name + " : " + message);
            this.ChatMemory(user);
        }

        /// <summary>
        /// Chats the memory.
        /// </summary>
        /// <param name="user">The user.</param>
        public void ChatMemory(User user)
        {
            chatRoomMessages.Add(user);
            return;
        }

        /// <summary>
        /// Chats the history.
        /// </summary>
        public void ChatHistory()
        {
            foreach (User chatRoom in chatRoomMessages)
            {
                Console.WriteLine(chatRoom.Name);
                Console.WriteLine(chatRoom.Message);
                Console.WriteLine("-------------------------------------------------");
            }
        }
    }
}
