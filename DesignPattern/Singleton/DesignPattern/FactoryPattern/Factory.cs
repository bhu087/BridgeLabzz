using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryPattern
{
    class Factory
    {
        public static void FactoryDeviceDetails()
        {
            CompuInterface compuObject = FactoryDriver.Choose();
            compuObject.Use();
            compuObject.OS();
            compuObject.Cost();
        }
    }
}
