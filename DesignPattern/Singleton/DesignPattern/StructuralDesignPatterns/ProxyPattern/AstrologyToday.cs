////------------------------------------------------------------------------
////<copyright file="AstrologyToday.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Astrology Today
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.ProxyPattern.IAstrology" />
    public class AstrologyToday : IAstrology
    {
        /// <summary>
        /// Gets the astrology.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>return astrology string</returns>
        public string GetAstrology(string name)
        {
            string[] todayString = { "today is good day for you", "hey! thats great", "Super day", "you will meet your friend" };
            Random random = new Random();
            string returnString = string.Empty;
            if (name.Length > 4 && name.Length <= 6)
            {
                Console.Write("Your name is Awesome and ");
                returnString = todayString[random.Next(3)];
            }

            if (name.Length <= 4)
            {
                Console.Write("Your name sounds good and ");
                returnString = todayString[random.Next(3)];
            }

            if (name.Length > 6)
            {
                Console.Write("Great name and ");
                returnString = todayString[random.Next(3)];
            }

            return returnString;
        }
    }
}
