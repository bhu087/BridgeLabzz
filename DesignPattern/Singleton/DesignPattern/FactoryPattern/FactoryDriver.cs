using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern
{
    class FactoryDriver
    {
        static CompuInterface compuInterface;
        public static CompuInterface Choose()
        {
            Console.WriteLine("type your option PC, Laptop, Server");
            string choice = Console.ReadLine();
            if (choice.ToLower().Equals("pc"))
            {
                compuInterface = new PC();
            }
            else if (choice.ToLower().Equals("laptop"))
            {
                compuInterface = new Laptop();
            }
            else if (choice.ToLower().Equals("server"))
            {
                compuInterface = new Server();
            }
            else
            {
                Console.WriteLine("No data available for your entry");
                Choose();
            }
            return compuInterface;
        }
    }
}
