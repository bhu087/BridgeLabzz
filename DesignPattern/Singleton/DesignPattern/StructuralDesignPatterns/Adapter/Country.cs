////------------------------------------------------------------------------
////<copyright file="Country.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Country
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.Adapter.IStates" />
    public class Country : IStates
    {
        /// <summary>
        /// Countries the states.
        /// </summary>
        /// <returns>
        /// returns list of states
        /// </returns>
        public List<string> CountryStates()
        {
            States states = new States();
            return states.StateList();
        }
    }
}
