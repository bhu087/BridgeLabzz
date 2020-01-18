using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class CalenderQueue
    {
        public static void MyQueueCalenderCall()
        {
            try
            {
                Console.WriteLine("Enter a year");
Year:           int Year = int.Parse(Console.ReadLine());
                if (Year > 9999 || Year < 1000)
                {
                    Console.WriteLine("Wrong year entry");
                    goto Year;
                }
                Console.WriteLine("Enter a Month JAN=1......DEC=12");
Month:          int Month = int.Parse(Console.ReadLine());
                if (Month > 12)
                {
                    Console.WriteLine("Wrong month");
                    goto Month;
                }
                Utility CalenderUTL = new Utility();
                CalenderUTL.CalenderQueueUtility(Year, Month);
            }
            catch (Exception)
            {
                Console.WriteLine("You are entered Wrong input");
            }
        }
    }
}
