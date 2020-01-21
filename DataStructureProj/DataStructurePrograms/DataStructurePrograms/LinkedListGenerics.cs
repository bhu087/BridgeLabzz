using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class LinkedListGenerics
    {
        public class MyLinkedList<T>
        {
            NodeGenerics<T> head;

            public void add(T Value)
            {
                if (head == null)
                {
                    head = new NodeGenerics<T>(Value);
                }
                //else it will check till next==null then added at tail
                else
                {
                    NodeGenerics<T> Current = head;
                    while (Current.Next != null)
                    {
                        Current = Current.Next;
                    }
                    Current.Next = new NodeGenerics<T>(Value);
                }
            }
            //it display all the data present in list
            public void Display()
            {
                if (IsEmpty())
                {
                    return;
                }
                NodeGenerics<T> Current = head;
                while (Current.Next != null)
                {
                    Console.WriteLine(Current.Data);
                    Current = Current.Next;
                }
                Console.WriteLine(Current.Data);
            }
            //Remove the value if it is already available in list
            public void remove(T Value)
            {
                //String StrValue = Value.ToString();
                NodeGenerics<T> Current = head;
                //it will check untill last NodeGenerics
                while (Current.Next != null)
                {
                    if (head == null)
                        return;
                    //it will check if the current data is equal or not
                    //if equal remove it
                    if (Current.Data.Equals(Value))
                    {
                        head = Current.Next;
                        remove(Value);
                    }
                    if (Current.Next.Data.Equals(Value))
                    {
                        Current.Next = Current.Next.Next;
                        return;
                    }
                    Current = Current.Next;
                }
            }
            //Search for Given string is available or no in list
            public bool search(T Value)
            {
                if (IsEmpty())
                {
                    return false;
                }
                //if available returns true else false
                NodeGenerics<T> Current = head;
                while (Current.Next != null)
                {
                    if (Current.Data.Equals(Value))
                    {
                        return true;
                    }
                    Current = Current.Next;
                }
                if (Current.Data.Equals(Value))
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
                NodeGenerics<T> Current = head;
                int Size = 0;
                while (Current.Next != null)
                {
                    Size++;
                    Current = Current.Next;
                }
                return Size + 1;
            }
            //append means add to the list only if the given value is not present in list
            public void Append(T Value)
            {
                if (search(Value))
                {
                    return;
                }
                else
                {
                    add(Value);
                }
            }
            //this gives the index values to given input
            public string index(T Value)
            {
                if (IsEmpty())
                {
                    return "List is empty";
                }
                NodeGenerics<T> Current = head;
                int indexValue = -1;
                string indexString = string.Empty;
                while (Current.Next != null)
                {
                    if (Current.Data.Equals(Value))
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
                if (Current.Data.Equals(Value))
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
            public void insert(int Position, T Value)
            {
                NodeGenerics<T> Current = head;
                NodeGenerics<T> TempNodeGenerics = new NodeGenerics<T>(Value);
                int Count = Position;
                if (search(Value))
                {
                    return;
                }
                if (Position == 0)
                {
                    addFirst(Value);
                    return;
                }
                //this needs position -1 time movement to forward required
                while (Count > 1)
                {
                    Current = Current.Next;
                    Count--;
                }
                TempNodeGenerics.Next = Current.Next;
                Current.Next = TempNodeGenerics;
            }
            //Add to the head
            public void addFirst(T Value)
            {
                NodeGenerics<T> Current = head;
                NodeGenerics<T> TempNodeGenerics = new NodeGenerics<T>(Value);
                TempNodeGenerics.Next = head;
                head = TempNodeGenerics;
            }
            //pop the value which is available at tail and remove it
            public T pop()
            {
                T Ans;
                if (IsEmpty())
                {
                    return default;
                }
                NodeGenerics<T> Current = head;
                if (Current.Next == null)
                {
                    Ans = Current.Data;
                    head = null;
                    return Ans;
                }
                while (Current.Next.Next != null)
                {
                    Current = Current.Next;
                }
                Ans = Current.Next.Data;
                Current.Next = null;
                return Ans;
            }
            //It removes the first element in the list and display it
            public T popFirst()
            {
                if (IsEmpty())
                {
                    return default;
                }
                NodeGenerics<T> Current = head;
                T Ans = Current.Data;
                head = Current.Next;
                return Ans;
            }
            //This gives the last indexed value
            public T getLast()
            {
                if (IsEmpty())
                {
                    return default;
                }
                NodeGenerics<T> Current = head;
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }
                return Current.Data;
            }
            //value at
            public T ValueAt(int Position)
            {
                if (Position < size())
                {
                    if (IsEmpty())
                    {
                        return default;
                    }
                    int count = Position;
                    NodeGenerics<T> Current = head;
                    while (count > 0)
                    {
                        Current = Current.Next;
                        count--;
                    }
                    return Current.Data;
                }
                return default;
            }
            //pop at the perticular position 
            public T pop(int Position)
            {
                if (Position > size() - 1)
                {
                    return default;
                }
                NodeGenerics<T> Current = head;
                int Count = Position;
                T Ans;
                if (Position == 0)
                {
                    Ans = popFirst();
                    return Ans;
                }
                while (Count > 1)
                {
                    Current = Current.Next;
                    Count--;
                }
                Ans = Current.Next.Data;
                Current.Next = Current.Next.Next;
                return Ans;
            }
        }
    }
}
