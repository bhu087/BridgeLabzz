using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    class UserAstrology
    {
        public static void UserAstrologyDetails()
        {
            Utility utility = new Utility();
            AstrologyProxy astrologyProxy = new AstrologyProxy();
            Console.WriteLine("Type your name");
            string name = Console.ReadLine();
            string astrology = astrologyProxy.GetAstrology(name);
            Console.WriteLine(astrology);

            Console.WriteLine("For repeat this press 1");
            if (utility.IntiInput() == 1)
            {
                UserAstrologyDetails();
            }
        }
    }
}
