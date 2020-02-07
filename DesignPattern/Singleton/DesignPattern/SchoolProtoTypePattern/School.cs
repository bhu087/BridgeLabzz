////------------------------------------------------------------------------
////<copyright file="School.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.SchoolProtoTypePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// School class
    /// </summary>
    public class School
    {
        /// <summary>
        /// Schools the details.
        /// </summary>
        public static void SchoolDetails()
        {
            Utility utility = new Utility();
            Console.WriteLine("1 for teachers\n2 for students");
            switch (utility.IntiInput())
            {
                case 1:
                    Teachers teacher1 = new Teachers();
                    Console.WriteLine("Enter Names");
                    teacher1.SetName(Console.ReadLine());
                    teacher1.SetCity("Bengaluru");
                    teacher1.SetEntryTime(10);
                    Teachers teacher2;
                    teacher2 = (Teachers)teacher1.GetClone();
                    teacher2.SetName(Console.ReadLine());
                    Console.WriteLine(teacher1.DetailsDisplay());
                    Console.WriteLine(teacher2.DetailsDisplay());
                    break;
                case 2:
                    Students student1 = new Students();
                    Console.WriteLine("Enter Names");
                    student1.SetName(Console.ReadLine());
                    student1.SetCity("Mangaluru");
                    student1.SetEntryTime(10);
                    Students student2;
                    student2 = (Students)student1.GetClone();
                    student2.SetName(Console.ReadLine());
                    Console.WriteLine(student1.DetailsDisplay());
                    Console.WriteLine(student2.DetailsDisplay());
                    break;
            }
        }
    }
}
