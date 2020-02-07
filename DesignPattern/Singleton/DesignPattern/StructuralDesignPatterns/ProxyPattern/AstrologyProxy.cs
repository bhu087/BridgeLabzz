using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    class AstrologyProxy : IAstrology
    {
        IAstrology astrology;
        public string GetAstrology(string name)
        {
            Utility utility = new Utility();
            Console.WriteLine("1 for today Astrology\n2 for tomorrow Astrology\n3 for this year Astrology");
            string returnString = string.Empty;
            int choice = utility.IntiInput();
            if (choice == 1)
            {
                astrology = new AstrologyToday();
                returnString = astrology.GetAstrology(name);
            }
            if (choice == 2)
            {
                astrology = new AstrologyTomorrow();
                returnString = astrology.GetAstrology(name);
            }
            if (choice == 3)
            {
                astrology = new AstrologyFuture();
                returnString = astrology.GetAstrology(name);
            }
            return returnString;
        }
    }
}
