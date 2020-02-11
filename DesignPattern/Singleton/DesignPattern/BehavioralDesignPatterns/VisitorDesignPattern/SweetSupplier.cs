////---------------------------------------------------------
////<copyright file="SweetSupplier.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////---------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Sweet supplier program
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern.IServicePersons" />
    public class SweetSupplier : IServicePersons
    {
        /// <summary>
        /// The sweets count
        /// </summary>
        private static int sweetsCount = 1;

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
            Console.WriteLine("{0} is providing Service to {1}, Sweet Count : {2}", this.name, kids.GetName(), sweetsCount);
            sweetsCount++;
        }
    }
}
