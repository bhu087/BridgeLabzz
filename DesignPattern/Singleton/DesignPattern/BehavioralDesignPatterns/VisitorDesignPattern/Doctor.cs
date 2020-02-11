////---------------------------------------------------------
////<copyright file="Doctor.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////---------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Doctor class
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern.IServicePersons" />
    public class Doctor : IServicePersons
    {
        /// <summary>
        /// The student count
        /// </summary>
        private static int studentCount = 1;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }

        /// <summary>
        /// Visits the specified kids.
        /// </summary>
        /// <param name="kids">The kids.</param>
        public void Visit(IKids kids)
        {
            Console.WriteLine("{0} is providing Service to {1}, Student No : {2}", this.name, kids.GetName(), studentCount);
            studentCount++;
        }
    }
}
