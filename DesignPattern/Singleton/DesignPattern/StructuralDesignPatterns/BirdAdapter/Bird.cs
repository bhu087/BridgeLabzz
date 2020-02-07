////------------------------------------------------------------------------
////<copyright file="Bird.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.BirdAdapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The bird
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.BirdAdapter.IBird" />
    class Bird : IBird
    {
        /// <summary>
        /// Makes the sound.
        /// </summary>
        public void MakeSound()
        {
            Console.WriteLine("Bird Make sound");
        }
    }
}
