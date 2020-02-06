using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern
{
    class Laptop : CompuInterface
    {
        public void Use()
        {
            Console.WriteLine("It's Used in Company, as well personal while travelling, its portable");
        }
        public void OS()
        {
            Console.WriteLine("Windows/Linux Machine");
        }
        public void Cost()
        {
            Console.WriteLine("Medium Cost");
        }
    }
}
