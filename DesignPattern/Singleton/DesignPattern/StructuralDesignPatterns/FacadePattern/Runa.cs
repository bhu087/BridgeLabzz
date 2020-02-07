using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    class Runa : IBook
    {
        public void Author()
        {
            Console.WriteLine("------------Runa-----------");
            List<string> authorList = new List<string>();
            authorList.Add("Kanaka");
            authorList.Add("Benaka");
            authorList.Add("Monika");
            foreach (string str in authorList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
