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
                                Console.WriteLine("true");
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }

        public void Register(string Id, string name, string mobile, string salary, string city)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spAddEmployee",sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("Id",Id);
                sqlCommand.Parameters.AddWithValue("FirstName",name);
                sqlCommand.Parameters.AddWithValue("Mobile",mobile);
                sqlCommand.Parameters.AddWithValue("Salary",salary);
                sqlCommand.Parameters.AddWithValue("City",city);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
