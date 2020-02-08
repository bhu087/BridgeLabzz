////------------------------------------------------------------------------
////<copyright file="RedMiY2.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the red mi mobile subject
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern.IProduct" />
    public class RedMiY2 : IProduct
    {
        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The price
        /// </summary>
        private int price;

        /// <summary>
        /// The version
        /// </summary>
        private float version;

        /// <summary>
        /// The customers
        /// </summary>
        private List<Customer> customers = new List<Customer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RedMiY2"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="price">The price.</param>
        /// <param name="version">The version.</param>
        public RedMiY2(string name, int price, float version)
        {
            this.name = name;
            this.price = price;
            this.version = version;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (!(this.name.Equals(value)))
                {
                    this.name = value;
                    this.Notify();
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (this.price != value)
                {
                    this.price = value;
                    this.Notify();
                }
            }
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public float Version
        {
            get
            {
                return this.version;
            }

            set
            {
                if (this.version != value)
                {
                    this.version = value;
                    this.Notify();
                }
            }
        }

        /// <summary>
        /// Subscribes the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void Subscribe(Customer customer)
        {
            this.customers.Add(customer);
        }

        /// <summary>
        /// Unsubscribes the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void Unsubscribe(Customer customer)
        {
            this.customers.Remove(customer);
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        public void Notify()
        {
            foreach (Customer customer in this.customers)
            {
                customer.Update(this, customer);
            }
        }
    }
}
