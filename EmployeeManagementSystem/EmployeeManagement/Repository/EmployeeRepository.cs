/////------------------------------------------------------------------------
////<copyright file="EmployeeRepository.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace EmployeeManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployeeManagement.Models;
    using EmployeeManagement.Utility;

    /// <summary>
    /// This is the Employee repository class
    /// </summary>
    /// <seealso cref="EmployeeManagement.Repository.IEmployeeRepository" />
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private string connectionString = ConnectionString.ConnectionName;

        /// <summary>
        /// Logins the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// returns the boolean value
        /// </returns>
        public bool Login(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployees", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader data = sqlCommand.ExecuteReader();
                while (data.Read())
                {
                    if (employee.Name.Equals(data["FirstName"].ToString()))
                    {
                        if (employee.Mobile.Equals(data["Mobile"].ToString()))
                        {
                            con.Close();
                            return true;
                        }
                    }
                }

                con.Close();
                return false;
            }
        }

        /// <summary>
        /// Registers the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void Register(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spAddEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("FirstName", employee.Name);
                sqlCommand.Parameters.AddWithValue("Mobile", employee.Mobile);
                sqlCommand.Parameters.AddWithValue("Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("City", employee.City);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>
        /// returns the List of employees
        /// </returns>
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetAllEmployees", sqlConnection);
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

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// returns the boolean value
        /// </returns>
        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                SqlCommand validateSqlCommand = new SqlCommand("spGetAllEmployees", sqlConnection);
                SqlCommand sqlCommand = new SqlCommand("spUpdateEmployee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("Id", Convert.ToInt32(employee.UserId));
                sqlCommand.Parameters.AddWithValue("FirstName", employee.Name);
                sqlCommand.Parameters.AddWithValue("Mobile", employee.Mobile);
                sqlCommand.Parameters.AddWithValue("Salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("City", employee.City);
                sqlConnection.Open();
                SqlDataReader data = validateSqlCommand.ExecuteReader();
                while (data.Read())
                {
                    string userIdInDB = data["Id"].ToString();
                    string userId = employee.UserId;
                    if (userIdInDB.Equals(userId))
                    {
                        sqlConnection.Close();
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        return true;
                    }
                } 

                sqlConnection.Close();
                return false;
            }
        }
    }
}
