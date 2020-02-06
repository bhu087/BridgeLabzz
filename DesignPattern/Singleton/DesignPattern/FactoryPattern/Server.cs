using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern
{
    class Server : CompuInterface
    {
        public void Use()
        {
            Console.WriteLine("It's Used in Company, for storing data, its not portable");
        }
        public void OS()
        {
            Console.WriteLine("Linux Machine");
        }
        public void Cost()
        {
            Console.WriteLine("High Cost");
        }
    }
}
