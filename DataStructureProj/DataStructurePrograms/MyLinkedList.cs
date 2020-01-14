﻿//<auto-generated/>
namespace DataStructurePrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class MyLinkedList
    {
        Node head;
        public MyLinkedList List()
        {
            return null;
        }
        //Adding the data at tail
        public void add(Object Value)
        {
            //if the head is null then value is aaded as a head
            String StrValue = Value.ToString();
            if (head == null)
            {
                head = new Node(StrValue);
            }
            //else it will check till next==null then added at tail
            else
            {
                Node Current = head;
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }
                Current.Next = new Node(StrValue);
            }
        }
        //it display all the data present in list
        public void Display()
        {
            if (IsEmpty())
            {
                return;
            }
            Node Current = head;
            while (Current.Next != null)
            {
                Console.WriteLine(Current.data);
                Current = Current.Next;
            }
            Console.WriteLine(Current.data);
        }
        //Remove the value if it is already available in list
        public void remove(Object Value)
        {
            String StrValue = Value.ToString();
            Node Current = head;
            //it will check untill last node
            while (Current.Next != null)
            {
                if (head == null)
                    return;
                //it will check if the current data is equal or not
                //if equal remove it
                if ((string)Current.data == StrValue)
                {
                    head = Current.Next;
                    remove(Value);
                }
                if ((string)Current.Next.data == StrValue)
                {
                    Current.Next = Current.Next.Next;
                    return;
                }
                Current = Current.Next;
            }
        }
        //Search for Given string is available or no in list
        public bool search(Object Value)
        {
            String StrValue = Value.ToString();
            if (IsEmpty())
            {
                return false;
            }
            //if available returns true else false
            Node Current = head;
            while (Current.Next != null)
            {
                if ((string)Current.data == StrValue)
                {
                    return true;
                }
                Current = Current.Next;
            }
            if ((string)Current.data == StrValue)
            {
                return true;
            }
            return false;
        }
        //is empty means head==null
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }

        //it gives the size of the array
        public int size()
        {
            if (IsEmpty())
            {
                return 0;
            }
            Node Current = head;
            int Size = 0;
            while (Current.Next != null)
            {
                Size++;
                Current = Current.Next;
            }
            return Size + 1;
        }
        //append means add to the list only if the given value is not present in list
        public void Append(Object Value)
        {
            String StrValue = Value.ToString();
            if (search(StrValue))
            {
                return;
            }
            else
            {
                add(StrValue);
            }
        }
        //this gives the index values to given input
        public string index(Object Value)
        {
            String StrValue = Value.ToString();
            if (IsEmpty())
            {
                return "List is empty";
            }
            Node Current = head;
            int indexValue = -1;
            string indexString = string.Empty;
            while (Current.Next != null)
            {
                if ((string)Current.data == StrValue)
                {
                    Current = Current.Next;
                    indexValue++;
                    indexString += indexValue + " ";
                }
                else
                {
                    Current = Current.Next;
                    indexValue++;
                }
            }
            if ((string)Current.data == StrValue)
            {
                indexValue++;
                indexString += indexValue + " ";
            }
            if (indexString.Length < 1)
            {
                return "Your Value not available";
            }
            else
                return "Your value available at " + indexString + "these indexes";
        }
        //insert at the given position
        public void insert(int Position, Object Value)
        {
            String StrValue = Value.ToString();
            Node Current = head;
            Node TempNode = new Node(StrValue);
            int Count = Position;
            if (search(StrValue))
            {
                return;
            }
            if (Position == 0)
            {
                addFirst(StrValue);
                return;
            }
            //this needs position -1 time movement to forward required
            while (Count > 1)
            {
                Current = Current.Next;
                Count--;
            }
            TempNode.Next = Current.Next;
            Current.Next = TempNode;
        }
        //Add to the head
        public void addFirst(Object Value)
        {
            String StrValue = Value.ToString();
            Node Current = head;
            Node TempNode = new Node(StrValue);
            TempNode.Next = head;
            head = TempNode;
        }
        //pop the value which is available at tail and remove it
        public Object pop()
        {
            if (IsEmpty())
            {
                return "List is empty";
            }
            Node Current = head;
            Object Ans = getLast();
            while (Current.Next.Next != null)
            {
                Current = Current.Next;
            }
            Current.Next = null;
            return Ans;
        }
        //It removes the first element in the list and display it
        public Object popFirst()
        {
            if (IsEmpty())
            {
                return "List is empty";
            }
            Node Current = head;
            Object Ans = Current.data;
            head = Current.Next;
            return Ans;
        }
        //This gives the last indexed value
        public Object getLast()
        {
            if (IsEmpty())
            {
                return "List is empty";
            }
            Node Current = head;
            while (Current.Next != null)
            {
                Current = Current.Next;
            }
            return Current.data;
        }
        //pop at the perticular position 
        public Object pop(int Position)
        {
            if (Position > size() - 1)
            {
                return "Invalid position";
            }
            Node Current = head;
            int Count = Position;
            Object Ans;
            if (Position == 0)
            {
                Ans = (Object)popFirst();
                return Ans;
            }
            while (Count > 1)
            {
                Current = Current.Next;
                Count--;
            }
            Ans = Current.Next.data;
            Current.Next = Current.Next.Next;
            return Ans;
        }
    }
}
