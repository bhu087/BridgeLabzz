using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    class AstrologyTomorrow : IAstrology
    {
        public string GetAstrology(string name)
        {
            Random random = new Random();
            string[] futureString = { "Tommorow you will eat doosa", "great day for you", "you will code ultimately", "Hey! great" };
            return futureString[random.Next(3)];
        }
    }
}
