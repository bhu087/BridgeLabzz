////------------------------------------------------------------------------
////<copyright file="IBird.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.BirdAdapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The bird interface
    /// </summary>
    public interface IBird
    {
        /// <summary>
        /// Makes the sound.
        /// </summary>
        void MakeSound();
    }
}
