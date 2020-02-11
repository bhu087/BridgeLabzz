////---------------------------------------------------------
////<copyright file="School.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////---------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the School And visitors visit here
    /// </summary>
    public class School
    {
        /// <summary>
        /// Schools the visitor.
        /// </summary>
        public static void SchoolVisitor()
        {
            Utility utility = new Utility();
            ////List of students in school
            List<IKids> kids = new List<IKids>();
            kids.Add(new KidsObject() { name = "Mahesh" });
            kids.Add(new KidsObject() { name = "Naresh" });
            kids.Add(new KidsObject() { name = "Sathish" });
            kids.Add(new KidsObject() { name = "Kumari" });
            kids.Add(new KidsObject() { name = "John" });
            ////taking the option from school head
            Console.WriteLine("Please Give your Input");
            Console.WriteLine("1 for Doctor\n2 for Sales Man\n3 for Sweet supplier");
            int option = utility.IntiInput();
            ServiceSection service = new ServiceSection();
            switch (option)
            {
                case 1:
                    Doctor doctor = new Doctor() { name = "Dr. M K Bhat" };
                    service.Service(doctor, kids);
                    break;
                case 2:
                    SalesMan salesMan = new SalesMan() { name = "Mr. Bharath" };
                    service.Service(salesMan, kids);
                    break;
                case 3:
                    SweetSupplier sweetSupplier = new SweetSupplier() { name = "Kanti Sweets" };
                    service.Service(sweetSupplier, kids);
                    break;
                default:
                    Console.WriteLine("You are entered Wrong input");
                    break;
            }
        }
    }
}
