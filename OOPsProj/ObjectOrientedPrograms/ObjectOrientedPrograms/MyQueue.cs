////...................................
////<copyright file="MyQueue.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////...................................
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Queue class
    /// </summary>
    public class MyQueue<T>
    {
        public Node<T> Head;

        /// <summary>
        /// Adds to queue.
        /// </summary>
        /// <param name="data">The data.</param>
        public void AddToQueue(T data)
        {
            Node<T> current = this.Head;
            Node<T> tempNode = new Node<T>(data);
            if (this.IsEmpty())
            {
                this.Head = new Node<T>(data);
                return;
            }

            tempNode.Next = current;
            this.Head = tempNode;
        }

        /// <summary>
        /// Removes from queue.
        /// </summary>
        /// <returns>string value</returns>
        public string RemoveFromQueue()
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return string.Empty;
            }

            Node<T> current = this.Head;
            string charValue;
            if (current.Next == null)
            {
                return Convert.ToString(current.Data);
            }

            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            charValue = Convert.ToString(current.Next.Data);
            current.Next = null;
            return charValue;
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
    }
}
