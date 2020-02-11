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
            servicePersons.Visit(this);
        }
        public string GetName()
        {
            return this.name;
        }
    }
}
