/////------------------------------------------------------------------------
////<copyright file="ConnectionString.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagement.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the Connection string class
    /// </summary>
    public class ConnectionString
    {
        /// <summary>
        /// The connection name
        /// </summary>
        private static string connectionName = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";

        /// <summary>
        /// Gets or sets the name of the connection.
        /// </summary>
        /// <value>
        /// The name of the connection.
        /// </value>
        public static string ConnectionName { get => connectionName; set => ConnectionName = value; }
    }
}
