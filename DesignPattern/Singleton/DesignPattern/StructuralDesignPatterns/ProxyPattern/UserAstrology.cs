////------------------------------------------------------------------------
////<copyright file="UserAstrology.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// User Astrology
    /// </summary>
    public class UserAstrology
    {
        /// <summary>
        /// Users the astrology details.
        /// </summary>
        public static void UserAstrologyDetails()
        {
            Utility utility = new Utility();
            AstrologyProxy astrologyProxy = new AstrologyProxy();
            Console.WriteLine("Type your name");
            string name = Console.ReadLine();
            string astrology = astrologyProxy.GetAstrology(name);
            Console.WriteLine(astrology);
            Console.WriteLine("For repeat this press 1");
            if (utility.IntiInput() == 1)
            {
                UserAstrologyDetails();
            }
        }
    }
}
