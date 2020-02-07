////------------------------------------------------------------------------
////<copyright file="AstrologyProxy.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Astrology proxy
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.ProxyPattern.IAstrology" />
    public class AstrologyProxy : IAstrology
    {
        /// <summary>
        /// The astrology
        /// </summary>
        private IAstrology astrology;

        /// <summary>
        /// Gets the astrology.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Astrology to user</returns>
        public string GetAstrology(string name)
        {
            Utility utility = new Utility();
            Console.WriteLine("1 for today Astrology\n2 for tomorrow Astrology\n3 for this year Astrology");
            string returnString = string.Empty;
            int choice = utility.IntiInput();
            if (choice == 1)
            {
                this.astrology = new AstrologyToday();
                returnString = this.astrology.GetAstrology(name);
            }

            if (choice == 2)
            {
                this.astrology = new AstrologyTomorrow();
                returnString = this.astrology.GetAstrology(name);
            }

            if (choice == 3)
            {
                this.astrology = new AstrologyFuture();
                returnString = this.astrology.GetAstrology(name);
            }

            return returnString;
        }
    }
}
