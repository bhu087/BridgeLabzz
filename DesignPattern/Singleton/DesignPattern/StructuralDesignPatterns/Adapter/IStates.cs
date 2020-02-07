////------------------------------------------------------------------------
////<copyright file="IStates.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// states Interface
    /// </summary>
    public interface IStates
    {
        /// <summary>
        /// Countries the states.
        /// </summary>
        /// <returns>returns list of states</returns>
        List<string> CountryStates();
    }
}
