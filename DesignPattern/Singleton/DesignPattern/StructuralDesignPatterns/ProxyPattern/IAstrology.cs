////------------------------------------------------------------------------
////<copyright file="IAstrology.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Astrology interface
    /// </summary>
    public interface IAstrology
    {
        /// <summary>
        /// Gets the astrology.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>returns string value</returns>
        string GetAstrology(string name);
    }
}
