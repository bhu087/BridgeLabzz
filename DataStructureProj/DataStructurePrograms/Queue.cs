using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class Queue
    {
        Node head;
        public void addToQueue(string Data)
        {
            Node Current = head;
            Node TempNode = new Node(Data);
            if (IsEmpty())
            {
                head = new Node(Data);
                return;
            }
            TempNode.Next = Current;
            head = TempNode;
        }
        public string RemoveFromQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return string.Empty;
            }
            Node Current = head;
            string CharValue;
            if (Current.Next == null)
            {
                return Convert.ToString(Current.data);
            }
            while (Current.Next.Next != null)
            {
                Current = Current.Next;
            }
            CharValue = Convert.ToString(Current.Next.data);
            Current.Next = null;
            return CharValue;
        }
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }
    }
}
