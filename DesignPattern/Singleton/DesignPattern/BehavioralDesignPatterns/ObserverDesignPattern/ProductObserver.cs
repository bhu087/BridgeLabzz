using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern
{
    class ProductObserver
    {
        public static void Observer()
        {
            NokiaRG nokia = new NokiaRG("Nokia", 1000, 12.01f);
            Customer customer = new Customer("Naveen",1234);
            nokia.Subscribe(customer);
            nokia.Price = 800;
            RedMiY2 redmi = new RedMiY2("Redmi", 2000, 18.01f);
            customer = new Customer("Saavan", 4567);
            redmi.Subscribe(customer);
            redmi.Price = 8100;
            Apple10S apple = new Apple10S("Apple", 3000, 10.01f);
            customer = new Customer("Dawan", 12147834);
            apple.Subscribe(customer);
            apple.Price = 1600;
        }
    }
}
