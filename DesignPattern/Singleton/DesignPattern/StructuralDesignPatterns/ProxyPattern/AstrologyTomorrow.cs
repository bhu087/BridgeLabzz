////------------------------------------------------------------------------
////<copyright file="AstrologyTomorrow.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Astrology for tomorrow
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.ProxyPattern.IAstrology" />
    public class AstrologyTomorrow : IAstrology
    {
        /// <summary>
        /// Gets the astrology.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>return astrology</returns>
        public string GetAstrology(string name)
        {
            Random random = new Random();
            string[] futureString = { "Tommorow you will eat doosa", "great day for you", "you will code ultimately", "Hey! great" };
            return futureString[random.Next(3)];
        }
    }
}
