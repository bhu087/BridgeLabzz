using System;

namespace DataStructurePrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList MLL = new MyLinkedList();
            MLL.add(10);
            MLL.add(20);
            MLL.add(30);
            MLL.add(40);
            MLL.add(50);
            Console.WriteLine(MLL.pop(4)+".......................");
            MLL.Display();
        }
    }
}
