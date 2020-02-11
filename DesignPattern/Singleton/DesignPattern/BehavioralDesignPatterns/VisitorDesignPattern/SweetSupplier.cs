using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    class SweetSupplier : IServicePersons
    {
        static int sweetsCount = 0;
        public string name { get; set; }
        public void Visit(IKids kids)
        {
            Console.WriteLine("{0} is providing Service to {1}, Sweet Count : {2}", this.name, kids.GetName(), sweetsCount);
            sweetsCount++;
        }
    }
}
