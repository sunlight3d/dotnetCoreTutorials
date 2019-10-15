using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public sealed class Database
    {

        private readonly String connetionString = @"Data Source=localhost;Initial Catalog=WinformExam;Integrated Security=True";
        private static Database instance = new Database();
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private String sqlString = "";
        private SqlDataReader sqlDataReader;

        static Database()
        {
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit  
        }
        public SqlConnection Connection
        { 
            get
            {
                sqlConnection = new SqlConnection(instance.connetionString);
                sqlConnection.Open();
                return sqlConnection;
            }
        }
        private Database()
        {

        }
        public static Database Instance
        {
            get
            { 
                return instance;
            }
        }
        public Boolean login(String UserName, String Password)
        {
            
            sqlString = "SELECT StudentCode FROM tblStudent " +
                        "WHERE UserName = @UserName AND Password = @Password";
            sqlCommand = new SqlCommand(sqlString, Connection);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                return true;
            }
            return false;
        }
    }
}
