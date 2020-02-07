using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    class Janapada : IBook
    {
        public void Author()
        {
            Console.WriteLine("------------Janapada-----------");
            List<string> authorList = new List<string>();
            authorList.Add("Basava");
            authorList.Add("Kumara");
            authorList.Add("Bandi");
            foreach (string str in authorList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
