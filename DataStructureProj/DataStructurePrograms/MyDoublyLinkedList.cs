using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class MyDoublyLinkedList<T>
    {
        NodeDoublyLinkedList<T> head;
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }
        
        public void Add(T Data)
        {
            NodeDoublyLinkedList<T> CurrentNode = head;
            NodeDoublyLinkedList<T> TempNode = new NodeDoublyLinkedList<T>(Data);
            if (head == null)
            {
                head = TempNode;
                return;
            }
            while (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
            }
            TempNode.Previous = CurrentNode;
            CurrentNode.Next = TempNode;
        }

        public void Display()
        {
            NodeDoublyLinkedList<T> CurrentNode = head;
            if (IsEmpty())
            {
                return;
            }
            while (CurrentNode.Next != null)
            {
                Console.WriteLine(CurrentNode.Data);
                CurrentNode = CurrentNode.Next;
            }
            Console.WriteLine(CurrentNode.Data);
        }

        public void Remove(T Data)
        {
            NodeDoublyLinkedList<T> CurrentNode = head;
RemoveHome: if (CurrentNode.Data.Equals(Data))
            {
                CurrentNode.Previous = null;
                head = CurrentNode.Next;
                CurrentNode = head;
                if (IsEmpty())
                {
                    return;
                }
                
                goto RemoveHome;
            }
            while (CurrentNode.Next != null)
            {
                if (CurrentNode.Data.Equals(Data))
                {
                    CurrentNode = CurrentNode.Previous;
                    CurrentNode.Next = CurrentNode.Next.Next;
                }
                CurrentNode = CurrentNode.Next;
            }
            if (CurrentNode.Data.Equals(Data))
            {
                CurrentNode = CurrentNode.Previous;
                CurrentNode.Next = null;
            }
        }

        public bool Search(T Data)
        {
            NodeDoublyLinkedList<T> CurrentNode = head;
            if (IsEmpty())
            {
                return false;
            }
            if ((CurrentNode.Data).Equals(Data))
            {
                return true;
            }
            while (CurrentNode.Next != null)
            { 
                if ((CurrentNode.Data).Equals(Data))
                {
                    return true;
                }
                CurrentNode = CurrentNode.Next;
            }
            if ((CurrentNode.Data).Equals(Data))
            {
                return true;
            }
            return false;
        }

        //Size
        public int Size()
        {
            NodeDoublyLinkedList<T> CurrentNode = head;
            int Count = 0;
            if (IsEmpty())
            {
                return 0;
            }
            while (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
                Count++;
            }
            Count++;
            return Count;
        }

        public void Append(T Data)
        {
            NodeDoublyLinkedList<T> CurrentNode = head;
            NodeDoublyLinkedList<T> TempNode = new NodeDoublyLinkedList<T>(Data);
            if (!Search(Data))
            {
                Add(Data);
            }
            else
            {
                Remove(Data);
            }
        }
    }
}
