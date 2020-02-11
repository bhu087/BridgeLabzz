////---------------------------------------------------------
////<copyright file="SalesMan.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////---------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Sales man Interface
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern.IServicePersons" />
    public class SalesMan : IServicePersons
    {
        /// <summary>
        /// The count
        /// </summary>
        private static int count = 1;

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
            Console.WriteLine("{0} is providing Service to {1}, Bag No : {2}", this.name, kids.GetName(), count);
            count++;
        }
    }
}
