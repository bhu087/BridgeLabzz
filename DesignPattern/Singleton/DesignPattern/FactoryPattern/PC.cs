using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern
{
    class PC : CompuInterface
    {
        public void Use()
        {
            Console.WriteLine("It's Used in Company, its not portable");
        }
        public void OS()
        {
            Console.WriteLine("Windows Machine");
        }
        public void Cost()
        {
            Console.WriteLine("Less Cost");
        }
    }
}
