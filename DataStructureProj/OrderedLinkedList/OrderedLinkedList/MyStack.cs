//auto-generated/>
namespace OrderedLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// this is the stsck memory push and pop operations are happening here
    /// </summary>
    class MyStack
    {
        Node head;
        //push to the linked list
        public void pushToStack(int Data)
        {
            Node CurrentNode = head;
            //list is empty then temp node is head
            Node TempNode = new Node(Data);
            if (head == null)
            {
                head = TempNode;
                return;
            }
            //else it will add at tail of the list
            while (CurrentNode.Next != null)
            {
                CurrentNode = CurrentNode.Next;
            }
            CurrentNode.Next = TempNode;
        }
        //pop from the linked list
        public int popFromStack()
        {
            Node CurrentNode = head;
            //if (head == null)
            //{
            //    return -1;
            //}
            //if only one node is available then it will return value make head node as null
            int Ans;
            if (CurrentNode.Next == null)
            {
                Ans = CurrentNode.Data;
                head = null;
                return Ans;
            }
            //else it will check till next.next value is null then returns the value and remove the last node
            while (CurrentNode.Next.Next != null)
            {
                CurrentNode = CurrentNode.Next;
            }
            Ans = CurrentNode.Next.Data;
            CurrentNode.Next = null;
            return Ans;
        }


    }
}
