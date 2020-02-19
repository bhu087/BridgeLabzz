using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Utility
{
    public class ConnectionString
    {
        private static string connectionName = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";
        public static string ConnectionName { get => connectionName; set => ConnectionName = value; }
    }
}
