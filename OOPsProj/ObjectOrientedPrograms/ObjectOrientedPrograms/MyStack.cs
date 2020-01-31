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
    class MyStack
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
        /// Pushes to list.
        /// </summary>
        public void Push(string details)
        {
            size++;
            transactionDetails.Add(details);
        }
    }
}
