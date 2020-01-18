using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedLinkedList
{
    class MyQueue
    {
        Node head;
        public void Enqueue(int Data)
        {
            Node CurrentNode = head;
            Node TempNode = new Node(Data);
            if (head == null)
            {
                head = TempNode;
                return;
            }
            while (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
            }
            CurrentNode.Next = TempNode;
        }

        public int Dequeue()
        {
            Node CurrentNode = head;
            int Ans;
            if (head == null)
            {
                return -1;
            }
            if (CurrentNode.Next == null)
            {
                Ans = CurrentNode.Data;
                head = null;
                return Ans;
            }
            Ans = CurrentNode.Data;
            head = CurrentNode.Next;
            return Ans;
        }
    }
}
