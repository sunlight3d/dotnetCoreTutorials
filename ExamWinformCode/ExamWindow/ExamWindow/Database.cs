using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;


namespace ExamWindow
{
    
    public sealed class Database
    {
        private String connetionString = @"Data Source=localhost;Initial Catalog=ExamWinForm;Integrated Security=True";
        private SqlConnection sqlConnection;
        private static readonly Database instance = new Database();
        private String sql;
        static Database()
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit  
        }
        private Database()
        {

        }
        public static Database Instance
        {
            get
            {
                instance.sqlConnection = new SqlConnection(instance.connetionString);
                instance.sqlConnection.Open();
                return instance;
            }
        }
        public DataTable GetAllDepartments() {
            DataTable dataTable = GetDataFromQuery("select * from Departments");
            return dataTable;
        }
        public DataTable GetEmployeesFromDeptID(String deptID)
        {
            sql = "select * from Employees where DeptID = @DeptID";
            DataTable dataTable = new DataTable();
            using (SqlCommand sqlCommand = new SqlCommand(sql, Database.Instance.sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@DeptID", deptID);

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlAdapter.Fill(dataTable);
                }
            }
            sqlConnection.Close();
            return dataTable;
        }
       
        public String GetDeptIDFromName(String deptName)
        {                     
            sql = "select * from Departments where DeptName = @DeptName";
            DataTable dataTable = new DataTable();
            using (SqlCommand sqlCommand = new SqlCommand(sql, Database.Instance.sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@DeptName", deptName);

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlAdapter.Fill(dataTable);
                }
            }
            sqlConnection.Close();
            foreach (DataRow row in dataTable.Rows)
            {
                return row["DeptID"].ToString();
            }
            return "";
        }
        public void DeleteEmployee(int employeeID)
        {
            sql = "delete from Employees where EmployeeID = @EmployeeID";
            DataTable dataTable = new DataTable();
            using (SqlCommand sqlCommand = new SqlCommand(sql, Database.Instance.sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@EmployeeID", employeeID);

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlAdapter.Fill(dataTable);
                }
            }
            sqlConnection.Close();            
        }
        public String InsertEmployee(Employee employee) {
            sql = "insert into Employees(EmployeeName,DeptID,Gender,BirthDate,Tel,Address) "+
                    "VALUES(@EmployeeName,@DeptID,@Gender,@BirthDate,@Tel,@Address)";
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, Database.Instance.sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.employeeName);
                    sqlCommand.Parameters.AddWithValue("@DeptID", employee.deptID);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.gender);
                    sqlCommand.Parameters.AddWithValue("@BirthDate", employee.birthDate);
                    sqlCommand.Parameters.AddWithValue("@Tel", employee.tel);
                    sqlCommand.Parameters.AddWithValue("@Address", employee.address);
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlAdapter.Fill(dataTable);
                        return "";
                    }
                }
            } catch(SqlException e) {
                Console.WriteLine("SQL Error:" + e.ToString());
                return e.ToString();
            }
            
        } 
        private DataTable GetDataFromQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = Database.Instance.sqlConnection;
                    sqlDataAdapter.SelectCommand = cmd;
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}
