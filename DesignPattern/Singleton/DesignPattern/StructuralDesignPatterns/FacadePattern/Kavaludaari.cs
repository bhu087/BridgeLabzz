////------------------------------------------------------------------------
////<copyright file="Kavaludaari.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Kavaludaari Book
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.FacadePattern.IBook" />
    class Kavaludaari : IBook
    {
        /// <summary>
        /// Authors this instance.
        /// </summary>
        public void Author()
        {
            Console.WriteLine("------------Kavaludaari-----------");
            List<string> authorList = new List<string>();
            authorList.Add("Nayana");
            authorList.Add("Kavana");
            authorList.Add("Buvana");
            foreach (string str in authorList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
