////...................................
////<copyright file="MyLinkedList.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////...................................
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is my Linked List.
    /// </summary>
    /// <typeparam name="T">Generics type Linked List</typeparam>
    public class MyLinkedList<T>
    {
        /// <summary>
        /// The Head
        /// </summary>
        public Node<T> Head;

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Add(T value)
        {
            ////if Head is null then node is Head
            ////else it will check till next==null then added at tail
            if (this.Head == null)
            {
                this.Head = new Node<T>(value);
            }
            else
            {
                Node<T> current = this.Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new Node<T>(value);
            }
        }

        /// <summary>
        /// Display the list.
        /// </summary>
        public void Display()
        {
            if (this.IsEmpty())
            {
                return;
            }

            Node<T> current = this.Head;
            while (current.Next != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }

            Console.WriteLine(current.Data);
        }
        
        /// <summary>
        /// Removes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Remove(T value)
        {
            ////String StrValue = Value.ToString();
            Node<T> current = this.Head;
            ////it will check untill last NodeGenerics
            while (current.Next != null)
            {
                if (this.Head == null)
                {
                    return;
                }

                ////it will check if the current data is equal or not
                ////if equal remove it
                if (current.Data.Equals(value))
                {
                    this.Head = current.Next;
                    this.Remove(value);
                }

                if (current.Next.Data.Equals(value))
                {
                    current.Next = current.Next.Next;
                    return;
                }

                current = current.Next;
            }
        }
        
        /// <summary>
        /// Searches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns boolean Value</returns>
        public bool Search(T value)
        {
            if (this.IsEmpty())
            {
                return false;
            }

            ////if available returns true else false
            Node<T> current = this.Head;
            while (current.Next != null)
            {
                if (current.Data.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            if (current.Data.Equals(value))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmpty()
        {
            if (this.Head == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sizes of this instance.
        /// </summary>
        /// <returns>Integer value</returns>
        public int Size()
        {
            if (this.IsEmpty())
            {
                return 0;
            }

            Node<T> current = this.Head;
            int size = 0;
            while (current.Next != null)
            {
                size++;
                current = current.Next;
            }

            return size + 1;
        }

        /// <summary>
        /// Appends the specified value if it is not exists in the list.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Append(T value)
        {
            if (this.Search(value))
            {
                return;
            }
            else
            {
                this.Add(value);
            }
        }

        /// <summary>
        /// Index of the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>String of index</returns>
        public string Index(T value)
        {
            if (this.IsEmpty())
            {
                return "List is empty";
            }

            Node<T> current = this.Head;
            int indexValue = -1;
            string indexString = string.Empty;
            while (current.Next != null)
            {
                if (current.Data.Equals(value))
                {
                    current = current.Next;
                    indexValue++;
                    indexString += indexValue + " ";
                }
                else
                {
                    current = current.Next;
                    indexValue++;
                }
            }

            if (current.Data.Equals(value))
            {
                indexValue++;
                indexString += indexValue + " ";
            }

            if (indexString.Length < 1)
            {
                return "Your Value not available";
            }
            else
            {
                return "Your value available at " + indexString + "these indexes";
            }
        }

        /// <summary>
        /// Insert to the specified position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        public void Insert(int position, T value)
        {
            Node<T> current = this.Head;
            Node<T> tempNode = new Node<T>(value);
            int count = position;
            if (this.Search(value))
            {
                return;
            }

            if (position == 0)
            {
                this.AddFirst(value);
                return;
            }

            ////this needs position -1 time movement to forward required
            while (count > 1)
            {
                current = current.Next;
                count--;
            }

            tempNode.Next = current.Next;
            current.Next = tempNode;
        }

        /// <summary>
        /// Adds the first.
        /// </summary>
        /// <param name="value">The value.</param>
        public void AddFirst(T value)
        {
            Node<T> tempNode = new Node<T>(value);
            tempNode.Next = this.Head;
            this.Head = tempNode;
        }

        /// <summary>
        /// Pop from the list.
        /// </summary>
        /// <returns>returns the generic value</returns>
        public T Pop()
        {
            T ans;
            if (this.IsEmpty())
            {
                return default;
            }

            Node<T> current = this.Head;
            if (current.Next == null)
            {
                ans = current.Data;
                this.Head = null;
                return ans;
            }

            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            ans = current.Next.Data;
            current.Next = null;
            return ans;
        }

        /// <summary>
        /// Pops the first.
        /// </summary>
        /// <returns>returns generic value</returns>
        public T PopFirst()
        {
            if (this.IsEmpty())
            {
                return default;
            }

            Node<T> current = this.Head;
            T ans = current.Data;
            this.Head = current.Next;
            return ans;
        }

        /// <summary>
        /// Gets the last.
        /// </summary>
        /// <returns>Returns Last value</returns>
        public T GetLast()
        {
            if (this.IsEmpty())
            {
                return default;
            }

            Node<T> current = this.Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Data;
        }

        /// <summary>
        /// Values at.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>Value at position</returns>
        public T ValueAt(int position)
        {
            if (position < this.Size())
            {
                if (this.IsEmpty())
                {
                    return default;
                }

                int count = position;
                Node<T> current = this.Head;
                while (count > 0)
                {
                    current = current.Next;
                    count--;
                }

                return current.Data;
            }

            return default;
        }

        /// <summary>
        /// Pops the specified position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>returns Value</returns>
        public T Pop(int position)
        {
            if (position > this.Size() - 1)
            {
                return default;
            }

            Node<T> current = this.Head;
            int count = position;
            T ans;
            if (position == 0)
            {
                ans = this.PopFirst();
                return ans;
            }

            while (count > 1)
            {
                current = current.Next;
                count--;
            }

            ans = current.Next.Data;
            current.Next = current.Next.Next;
            return ans;
        }
        
    }
}
