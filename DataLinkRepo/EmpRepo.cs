using ModelRepo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace DataLinkRepo
{
    
   public class EmpRepo:IEmpRepo
    {
        string con = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;

        public List<Employee> GetAllEmpData()
        {
            List<Employee> empdata = new List<Employee>();
            using(SqlConnection conn = new SqlConnection(con))
            {
                string query = "SELECT * FROM EmployeeTBL";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.Empid = Convert.ToInt32(reader["EmployeeID"]);
                        emp.Fname = reader["FirstName"].ToString();
                        emp.Lname = reader["LastName"].ToString();
                        emp.Email = reader["Email"].ToString();
                        emp.Salary = Convert.ToDecimal(reader["Salary"]);
                        emp.Phone = reader["Phone"].ToString();
                        emp.HireDate = Convert.ToDateTime(reader["HireDate"]);

                        empdata.Add(emp);
                    }
                }
            }
            return empdata;
        }
    }
}
