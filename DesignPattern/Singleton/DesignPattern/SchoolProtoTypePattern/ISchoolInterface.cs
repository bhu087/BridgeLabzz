////------------------------------------------------------------------------
////<copyright file="ISchoolInterface.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.SchoolProtoTypePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// School interface
    /// </summary>
    public interface ISchoolInterface
    {
        /// <summary>
        /// Gets the clone.
        /// </summary>
        /// <returns>returns interface</returns>
        ISchoolInterface GetClone();

        /// <summary>
        /// Detailses the display.
        /// </summary>
        /// <returns>returns string value</returns>
        string DetailsDisplay();
    }
}
