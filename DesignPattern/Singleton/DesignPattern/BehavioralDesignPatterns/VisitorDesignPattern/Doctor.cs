using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    class Doctor : IServicePersons
    {
        static int studentCount;
        public string name { get; set; }
        public void Visit(IKids kids)
        {
            Console.WriteLine("{0} is providing Service to {1} Student No : {2}", this.name, kids.GetName(), studentCount);
            studentCount++;
        }
    }
}
