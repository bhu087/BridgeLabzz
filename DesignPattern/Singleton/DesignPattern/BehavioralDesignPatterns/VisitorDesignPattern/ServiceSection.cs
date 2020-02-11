using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.VisitorDesignPattern
{
    class ServiceSection
    {
        /// <summary>
        /// Services the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="kids">The kids.</param>
        public void Service(IServicePersons serviceProvider, List<IKids> kids)
        {
            foreach (var kid in kids)
            {
                serviceProvider.Visit(kid);
            }
        }
    }
}
