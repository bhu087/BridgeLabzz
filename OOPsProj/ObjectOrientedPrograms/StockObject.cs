////...................................
////<copyright file="StockObject.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////...................................
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the StockObject class
    /// </summary>
    public class StockObject
    {
        /// <summary>
        /// Gets or sets the name of the stock.
        /// </summary>
        /// <value>
        /// The name of the stock.
        /// </value>
        public string StockName { get; set;  }

        /// <summary>
        /// Gets or sets the number of share.
        /// </summary>
        /// <value>
        /// The number of share.
        /// </value>
        public int NumberOfShare { get; set;  }

        /// <summary>
        /// Gets or sets the share price.
        /// </summary>
        /// <value>
        /// The share price.
        /// </value>
        public int SharePrice { get; set;  }
    }
}
