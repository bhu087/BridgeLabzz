using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class DoublyLinkedListProgram
    {
        public static void DoublyLinkedList()
        {
            MyDoublyLinkedList<string> MyList = new MyDoublyLinkedList<string>();
            //MyList.Add("Hi");
            //MyList.Add("Hi");
            MyList.Add("Hi");
            MyList.Add("Hello");
            MyList.Add("Namaskara");
            MyList.Add("Hi");
            MyList.Append("Hi");
            Console.WriteLine(MyList.Search("Hello"));
            MyList.Display();
            Console.WriteLine(MyList.Size());
        }
    }
}
