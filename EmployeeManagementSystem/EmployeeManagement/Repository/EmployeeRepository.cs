using EmployeeManagement.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string connectionString = ConnectionString.ConnectionName;
        
        public bool Login(string name, string userId, string mobile)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployee", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader data= sqlCommand.ExecuteReader();
                while (data.Read())
                {
                    if (userId.Equals(data["Id"]))
                    {
                        if (name.Equals(data["FirstName"]))
                        {
                            if (mobile.Equals(data["Mobile"]))
                            {
                                con.Close();
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }
    }
}
