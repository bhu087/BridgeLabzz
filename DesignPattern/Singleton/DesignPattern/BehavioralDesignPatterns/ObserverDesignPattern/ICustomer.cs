using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.ObserverDesignPattern
{
    interface ICustomer
    {
        void Update(NokiaRG product, Customer customer);
        void Update(Apple10S product, Customer customer);
        void Update(RedMiY2 product, Customer customer);
    }
}
