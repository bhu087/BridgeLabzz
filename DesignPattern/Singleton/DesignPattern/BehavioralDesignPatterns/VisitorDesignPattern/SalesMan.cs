using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    class SalesMan : IServicePersons
    {
        static int count;
        public string name { get; set; }
        public void Visit(IKids kids)
        {
            Console.WriteLine("{0} is providing Service to {1} Bag No : {2}", this.name, kids.GetName(), count);
            count++;
        }
    }
}
