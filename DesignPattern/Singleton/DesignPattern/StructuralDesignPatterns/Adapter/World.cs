////------------------------------------------------------------------------
////<copyright file="World.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// World class
    /// </summary>
    public class World
    {
        /// <summary>
        /// State the view.
        /// </summary>
        public static void StatesView()
        {
            IStates country = new Country();
            foreach (string str in country.CountryStates())
            {
                Console.WriteLine(str);
            }
        }
    }
}
