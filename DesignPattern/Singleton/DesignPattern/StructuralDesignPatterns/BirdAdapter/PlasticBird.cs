////------------------------------------------------------------------------
////<copyright file="PlasticBird.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.BirdAdapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// the plastic bird
    /// </summary>
    class PlasticBird
    {
        /// <summary>
        /// Speaks this instance.
        /// </summary>
        public void Speak()
        {
            Console.WriteLine("It can Speak");
        }
    }
}
