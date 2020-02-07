////------------------------------------------------------------------------
////<copyright file="Teachers.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.SchoolProtoTypePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Teachers class
    /// </summary>
    /// <seealso cref="DesignPattern.SchoolProtoTypePattern.ISchoolInterface" />
    public class Teachers : ISchoolInterface
    {
        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The city
        /// </summary>
        private string city;

        /// <summary>
        /// The entry time
        /// </summary>
        private int entryTime;

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Sets the city.
        /// </summary>
        /// <param name="city">The city.</param>
        public void SetCity(string city)
        {
            this.city = city;
        }

        /// <summary>
        /// Sets the entry time.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public void SetEntryTime(int entry)
        {
            this.entryTime = entry;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>return Name</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <returns>return city</returns>
        public string GetCity()
        {
            return this.city;
        }

        /// <summary>
        /// Gets the entry time.
        /// </summary>
        /// <returns>return entry time</returns>
        public int GetEntryTime()
        {
            return this.entryTime;
        }

        /// <summary>
        /// Gets the clone.
        /// </summary>
        /// <returns>
        /// returns interface
        /// </returns>
        public ISchoolInterface GetClone()
        {
            return (ISchoolInterface)this.MemberwiseClone();
        }

        /// <summary>
        /// Details display.
        /// </summary>
        /// <returns>
        /// returns string value
        /// </returns>
        public string DetailsDisplay()
        {
            return "Teacher Name : " + this.name + ", School City : " + this.city + ", Entry Time : " + this.entryTime;
        }
    }
}
