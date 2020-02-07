////------------------------------------------------------------------------
////<copyright file="AstrologyFuture.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Astrology for future
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.ProxyPattern.IAstrology" />
    public class AstrologyFuture : IAstrology
    {
        /// <summary>
        /// Gets the astrology.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>future astrology it will returns</returns>
        public string GetAstrology(string name)
        {
            Random random = new Random();
            string[] futureString = { "you will marry at 30", "you will buy car this year end", "Goa trip", "life is jindalala" };
            return futureString[random.Next(3)];
        }
    }
}
