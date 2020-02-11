using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    public interface IKids
    {
        void Accept(IServicePersons servicePersons);
        string GetName();
    }
}
