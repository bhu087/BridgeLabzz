////---------------------------------------------------------
////<copyright file="IServicePersons.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////---------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the service persons interface(Visitors)
    /// </summary>
    public interface IServicePersons
    {
        /// <summary>
        /// Visits the specified kids.
        /// </summary>
        /// <param name="kids">The kids.</param>
        void Visit(IKids kids);
    }
}
