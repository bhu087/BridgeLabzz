////------------------------------------------------------------------------
////<copyright file="IProduct.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// the product interface
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Notifies this instance.
        /// </summary>
        void Notify(); 
    }
}
