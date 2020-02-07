////------------------------------------------------------------------------
////<copyright file="IBook.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The book interface
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// Authors this instance.
        /// </summary>
        void Author();
    }
}
