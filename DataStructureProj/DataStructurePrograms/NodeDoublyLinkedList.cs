using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class NodeDoublyLinkedList<T>
    {
        public NodeDoublyLinkedList<T> Next;
        public NodeDoublyLinkedList<T> Previous;
        public T Data;
        public NodeDoublyLinkedList(T Data)
        {
            this.Data = Data;
        }
    }
}
