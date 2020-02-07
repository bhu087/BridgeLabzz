////------------------------------------------------------------------------
////<copyright file="BirdFinder.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.BirdAdapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Bird Finder
    /// </summary>
    class BirdFinder
    {
        /// <summary>
        /// Birds the sound.
        /// </summary>
        public static void BirdSound()
        {
            IBird bird = new Bird();
            bird.MakeSound();
            IBird bird1 = new BirdAdapter(new PlasticBird());
            bird1.MakeSound();
        }
    }
}
