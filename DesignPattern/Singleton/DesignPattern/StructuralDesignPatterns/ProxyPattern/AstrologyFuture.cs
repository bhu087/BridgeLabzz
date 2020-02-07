using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StructuralDesignPatterns.ProxyPattern
{
    class AstrologyFuture : IAstrology
    {
        public string GetAstrology(string name)
        {
            Random random = new Random();
            string[] futureString = { "you will marry at 30", "you will buy car this year end", "Goa trip", "life is jindalala" };
            return futureString[random.Next(3)];
        }
    }
}
