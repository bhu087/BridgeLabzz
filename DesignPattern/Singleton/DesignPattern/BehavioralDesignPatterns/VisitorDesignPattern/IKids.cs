////---------------------------------------------------------
////<copyright file="IKids.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////---------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the kids interface
    /// </summary>
    public interface IKids
    {
        /// <summary>
        /// Accepts the specified service persons.
        /// </summary>
        /// <param name="servicePersons">The service persons.</param>
        void Accept(IServicePersons servicePersons);

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>Name of the kid</returns>
        string GetName();
    }
}
