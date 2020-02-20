using EmployeeManagement.Models;
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
        
        public bool Login(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployees", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader data= sqlCommand.ExecuteReader();
                while (data.Read())
                {
                    if (employee.Name.Equals(data["FirstName"]))
                    {
                        if (employee.Mobile.Equals(data["Mobile"]))
                        {
                            con.Close();
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public void Register(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spAddEmployee",sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue("Id", employee.UserId);
                sqlCommand.Parameters.AddWithValue("FirstName", employee.Name);
                sqlCommand.Parameters.AddWithValue("Mobile", employee.Mobile);
                sqlCommand.Parameters.AddWithValue("Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("City", employee.City);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployees",sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader data = sqlCommand.ExecuteReader();
                while (data.Read())
                {
                    Employee employee = new Employee();
                    employee.UserId = data["Id"].ToString();
                    employee.Name = data["FirstName"].ToString();
                    employee.Mobile = data["Mobile"].ToString();
                    employee.Salary = data["Salary"].ToString();
                    employee.City = data["City"].ToString();
                    list.Add(employee);
                }
                sqlConnection.Close();
            }
            return list;
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployee",sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("Id",Convert.ToInt32(employee.UserId));
                sqlCommand.Parameters.AddWithValue("FirstName",employee.Name);
                sqlCommand.Parameters.AddWithValue("Mobile",employee.Mobile);
                sqlCommand.Parameters.AddWithValue("Salary",employee.Salary);
                sqlCommand.Parameters.AddWithValue("City",employee.City);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
        }
    }
}
