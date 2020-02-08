using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern
{
    class RedMiY2 : IProduct
    {
        private string name;
        private int price;
        private float version;
        List<Customer> customers = new List<Customer>();
        public RedMiY2(string name, int price, float version)
        {
            this.name = name;
            this.price = price;
            this.version = version;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!(this.name.Equals(value)))
                {
                    this.name = value;
                    Notify();
                }
                this.name = value;
            }
        }
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
                    Notify();
                }
            }
        }
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
                    Notify();
                }
            }
        }

        public void Subscribe(Customer customer)
        {
            customers.Add(customer);
        }
        public void Unsubscribe(Customer customer)
        {
            customers.Remove(customer);
        }

        public void Notify()
        {
            foreach (Customer customer in customers)
            {
                customer.Update(this, customer);
            }
        }
    }
}
