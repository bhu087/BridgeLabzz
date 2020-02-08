////------------------------------------------------------------------------
////<copyright file="Customer.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The customer
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern.ICustomer" />
    public class Customer : ICustomer
    {
        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The identifier
        /// </summary>
        private int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="id">The identifier.</param>
        public Customer(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="customer">The customer.</param>
        public void Update(NokiaRG product, Customer customer)
        {
            Console.WriteLine("Dear {0},\nYou have a notification {1}, is updated as {2} INR and {3} version", customer.name, product.Name, product.Price, product.Version);
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="customer">The customer.</param>
        public void Update(Apple10S product, Customer customer)
        {
            Console.WriteLine("Dear {0},\nYou have a notification {1}, is updated as {2} INR and {3} version", customer.name, product.Name, product.Price, product.Version);
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="customer">The customer.</param>
        public void Update(RedMiY2 product, Customer customer)
        {
            Console.WriteLine("Dear {0},\nYou have a notification {1}, is updated as {2} INR and {3} version", customer.name, product.Name, product.Price, product.Version);
        }
    }
}
