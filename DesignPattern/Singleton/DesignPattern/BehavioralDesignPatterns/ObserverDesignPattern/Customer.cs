using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern
{
    class Customer : ICustomer
    {
        private string name;
        private int id;
        public Customer(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
        public void Update(NokiaRG product,Customer customer)
        {
            Console.WriteLine("Dear {0},\nYou have a notification {1}, is updated as {2} INR and {3} version", customer.name, product.Name, product.Price, product.Version);
        }
        public void Update(Apple10S product, Customer customer)
        {
            Console.WriteLine("Dear {0},\nYou have a notification {1}, is updated as {2} INR and {3} version", customer.name, product.Name, product.Price, product.Version);
        }
        public void Update(RedMiY2 product, Customer customer)
        {
            Console.WriteLine("Dear {0},\nYou have a notification {1}, is updated as {2} INR and {3} version", customer.name, product.Name, product.Price, product.Version);
        }
    }
}
