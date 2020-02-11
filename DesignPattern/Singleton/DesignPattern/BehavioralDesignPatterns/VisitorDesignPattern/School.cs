using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    class School
    {
        public static void SchoolVisitor()
        {
            Utility utility = new Utility();
            
            List<IKids> kids = new List<IKids>();
            kids.Add(new KidsObject() { name = "Mahesh"});
            kids.Add(new KidsObject() { name = "Naresh"});
            kids.Add(new KidsObject() { name = "Sathish"});
            kids.Add(new KidsObject() { name = "Kumari"});
            kids.Add(new KidsObject() { name = "John"});
            Console.WriteLine("Please Give your Input");
            Console.WriteLine("1 for Doctor\n2 for Sales Man\n3 for Sweet supplier");
            int option = utility.IntiInput();
            switch (option)
            {
                case 1:
                    Doctor doctor = new Doctor() { name = "Dr. M K Bhat" };
                    Service(doctor,kids);
                    break;
                case 2:
                    SalesMan salesMan = new SalesMan() { name = "Mr. Bharath"};
                    Service(salesMan, kids);
                    break;
                case 3:
                    SweetSupplier sweetSupplier = new SweetSupplier() { name = "Kanti Sweets"};
                    Service(sweetSupplier, kids);
                    break;
                default:
                    Console.WriteLine("You are entered Wrong input");
                    break;
            }
        }
        public static void Service(IServicePersons serviceProvider, List<IKids> kids)
        {
            foreach (var kid in kids)
            {
                serviceProvider.Visit(kid);
            }
        }
    }
}
