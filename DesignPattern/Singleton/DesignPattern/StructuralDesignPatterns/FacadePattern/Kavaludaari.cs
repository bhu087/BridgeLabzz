using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    class Kavaludaari : IBook
    {
        public void Author()
        {
            Console.WriteLine("------------Kavaludaari-----------");
            List<string> authorList = new List<string>();
            authorList.Add("Nayana");
            authorList.Add("Kavana");
            authorList.Add("Buvana");
            foreach (string str in authorList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
