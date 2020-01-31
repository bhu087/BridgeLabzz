////...................................
////<copyright file="MyStack.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////...................................
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is my stack
    /// </summary>
    public class MyStack
    {
        /// <summary>
        /// The transaction details List
        /// </summary>
        public static MyLinkedList<string> transactionDetails = new MyLinkedList<string>();

        /// <summary>
        /// The size of Stack
        /// </summary>
        static int size = 0;

        /// <summary>
        /// Push the details to list.
        /// </summary>
        /// <param name="details">The details.</param>
        public void Push(string details)
        {
            size++;
            transactionDetails.Add(details);
        }

        /// <summary>
        /// Pop from the list.
        /// </summary>
        /// <returns> it sends the status of the transaction </returns>
        public string Pop()
        {
            if (size == 0)
            {
                return "stack is empty";
            }

            size--;
            return transactionDetails.Pop();
        }

        /// <summary>
        /// Sizeof the List.
        /// </summary>
        /// <returns> size of the stack</returns>
        public int Size()
        {
            return size;
        }
    }
}
