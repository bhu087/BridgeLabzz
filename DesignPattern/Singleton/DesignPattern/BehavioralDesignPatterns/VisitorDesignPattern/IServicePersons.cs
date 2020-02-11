using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    public interface IServicePersons
    {
        void Visit(IKids kids);
    }
}
