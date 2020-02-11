using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    class KidsObject : IKids
    {
        public string name { get; set; }
        public void Accept(IServicePersons servicePersons)
        {
            Console.WriteLine();
        }
    }
}
