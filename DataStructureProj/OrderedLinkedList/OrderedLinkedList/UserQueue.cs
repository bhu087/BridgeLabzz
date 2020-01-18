using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedLinkedList
{
    class UserQueue
    {
        MyQueue myQueue = new MyQueue();
        int QueueSize = 0;
        int Answer;
        public void Enqueue(int Data)
        {
            myQueue.Enqueue(Data);
            QueueSize++;
        }
        public int Dequeue()
        {
            if (QueueSize <= 0)
            {
                return -1;
            }
            Answer = myQueue.Dequeue();
            QueueSize--;
            return Answer;
        }
        public bool IsEmptyQueue()
        {
            if (QueueSize == 0)
            {
                return true;
            }
            return false;
        }
    }
}
