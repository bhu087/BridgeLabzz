////------------------------------------------------------------------------
////<copyright file="States.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The States
    /// </summary>
    public class States
    {
        /// <summary>
        /// States the list.
        /// </summary>
        /// <returns>returns list</returns>
        public List<string> StateList()
        {
            List<string> list = new List<string>();
            list.Add("Karnataka");
            list.Add("Andra");
            list.Add("Maharastra");
            list.Add("Kerala");
            list.Add("Telangana");
            return list;
        }
    }
}
