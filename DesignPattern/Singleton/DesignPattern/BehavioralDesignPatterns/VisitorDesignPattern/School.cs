using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    class School
    {
        public static void SchoolVisitor()
        {
            List<IKids> kids = new List<IKids>();
            kids.Add(new KidsObject() { name = "Mahesh"});
            kids.Add(new KidsObject() { name = "Naresh"});
            kids.Add(new KidsObject() { name = "Sathish"});
            kids.Add(new KidsObject() { name = "Kumari"});
            kids.Add(new KidsObject() { name = "John"});
            Doctor doctor = new Doctor();
            foreach (var kid in kids)
            {
                doctor.Visit(kid);
            }
        }
    }
}
