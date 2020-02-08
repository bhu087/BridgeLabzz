////------------------------------------------------------------------------
////<copyright file="ICustomer.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Customer interface
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="customer">The customer.</param>
        void Update(NokiaRG product, Customer customer);

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="customer">The customer.</param>
        void Update(Apple10S product, Customer customer);

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="customer">The customer.</param>
        void Update(RedMiY2 product, Customer customer);
    }
}
