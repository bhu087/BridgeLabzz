using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class MyLinkedList
    {
        Node head;
        public MyLinkedList List()
        {
            return null;
        }     
        public void add(int Value)
        {
            if (head == null)
            {
                head = new Node(Value);
            }
            else
            {
                Node Current = head;
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }
                Current.Next = new Node(Value);
            }
        }
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

        public void remove(int Value)
        {
            Node Current = head;
            while (Current.Next != null)
            {
                if (head == null)
                    return;
                if (Current.data == Value)
                {
                    head = Current.Next;
                    remove(Value);
                }
                if (Current.Next.data == Value)
                {
                    Current.Next = Current.Next.Next;
                    return;
                }
                Current = Current.Next;
            }
        }

        public bool search(int Value)
        {
            if (IsEmpty())
            {
                return false;
            }
            Node Current = head;
            while (Current.Next != null)
            {
                if (Current.data == Value)
                {
                    return true;
                }
                Current = Current.Next;
            }
            if (Current.data == Value)
            {
                return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            return false;
        }

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

        public void Append(int Value)
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

        public string index(int Value)
        {
            if (IsEmpty())
            {
                return "List is empty";
            }
            Node Current = head;
            int indexValue = -1;
            string indexString = string.Empty;
            while (Current.Next != null)
            {
                if (Current.data == Value)
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
            if(Current.data == Value)
            {
                indexValue++;
                indexString += indexValue + " ";
            }
            if (indexString.Length < 1)
            {
                return "Your Value not available";
            }
            else
            return "Your value available at "+indexString+"these indexes";
        }

        public void insert(int Position, int Value)
        {
            Node Current = head;
            Node TempNode=new Node(Value);
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
            TempNode.Next = Current.Next;
            Current.Next = TempNode;
        }

        public void addFirst(int Value)
        {
            Node Current = head;
            Node TempNode = new Node(Value);
            TempNode.Next = head;
            head = TempNode;
        }

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

        public Object popFirst()
        {
            if (IsEmpty())
            {
                return "List is empty";
            }
            Node Current = head;
            int Ans = Current.data;
            head = Current.Next;
            return Ans;
        }
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

        public Object pop(int Position)
        {
            if(Position>size()-1) 
            {
                return "Invalid position";
            }
            Node Current = head;
            int Count = Position;
            int Ans;
            if (Position == 0)
            {
                Ans = (int)popFirst();
                return Ans;
            }
            while (Count>1)
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
