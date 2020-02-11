using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    class SweetSupplier : IServicePersons
    {
        private string name { get; set; }
        public void Visit(IKids kids)
        {
            Console.WriteLine("{0} is providing Service to {1}", this.name, kids.GetName());
        }
    }
}
