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
    public class MyQueue
    {
        /// <summary>
        /// The date list
        /// </summary>
        public static MyLinkedList<DateTime> dateList = new MyLinkedList<DateTime>();

        /// <summary>
        /// size of Queue
        /// </summary>
        int size = 0;

        /// <summary>
        /// Adds the date time to list.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        public void Add(DateTime dateTime)
        {
            dateList.Add(dateTime);
            this.size++;
        }

        /// <summary>
        /// Deletes the first entry.
        /// </summary>
        public void Delete()
        {
            if (dateList.IsEmpty())
            {
                return;
            }

            dateList.PopFirst();
            this.size--;
        }

        /// <summary>
        /// Size of this instance.
        /// </summary>
        /// <returns>returns size of list</returns>
        public int Size()
        {
            return this.size;
        }
    }
}
