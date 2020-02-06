using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Utility
    {
        public int IntiInput()
        {
            int intValue;
            bool success = int.TryParse(Console.ReadLine(), out intValue);
            if (success)
            {
                return intValue;
            }
            else 
            {
                Console.WriteLine("Invalid Entry");
                this.IntiInput();
                return 0;
            }
        }
    }
}
