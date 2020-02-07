////------------------------------------------------------------------------
////<copyright file="BookFacade.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Runa book
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.FacadePattern.IBook" />
    class Runa : IBook
    {
        /// <summary>
        /// Authors this instance.
        /// </summary>
        public void Author()
        {
            Console.WriteLine("------------Runa-----------");
            List<string> authorList = new List<string>();
            authorList.Add("Kanaka");
            authorList.Add("Benaka");
            authorList.Add("Monika");
            foreach (string str in authorList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
