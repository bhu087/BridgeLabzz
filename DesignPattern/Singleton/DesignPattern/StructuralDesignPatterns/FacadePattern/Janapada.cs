////------------------------------------------------------------------------
////<copyright file="Janapada.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// janapada book
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.FacadePattern.IBook" />
    public class Janapada : IBook
    {
        /// <summary>
        /// Authors this instance.
        /// </summary>
        public void Author()
        {
            Console.WriteLine("------------Janapada-----------");
            List<string> authorList = new List<string>();
            authorList.Add("Basava");
            authorList.Add("Kumara");
            authorList.Add("Bandi");
            foreach (string str in authorList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
