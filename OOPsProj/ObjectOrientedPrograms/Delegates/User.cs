using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms.Delegates
{
    class User
    {
        public string name { get; set; }
        public void GetMessage(string person)
        {
            Console.WriteLine("Hi {0}, {1} Calls you", this.name, person);
        }
    }
}
