using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class CustomerContactInfo
    {
        public string ContactNumber { get; set; }
        public string place { get; set; }
        public CustomerContactInfo GetClone()
        {
            return (CustomerContactInfo)this.MemberwiseClone();
        }
    }
}
