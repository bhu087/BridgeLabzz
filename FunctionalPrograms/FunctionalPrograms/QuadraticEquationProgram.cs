﻿// <auto-generated/>
namespace FunctionalPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// this is a quadratic equation program
    /// </summary>
    class QuadraticEquationProgram
    {
        public static void Quadratic()
        {
            Utility UL = new Utility();
            Console.WriteLine("Enter value of 'a'");
            double a = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of 'b'");
            double b = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of 'c'");
            double c = Double.Parse(Console.ReadLine());
            UL.FindRoots(a, b, c);


        }
    }
}
