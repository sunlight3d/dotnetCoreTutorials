using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWindow
{
    
    public sealed class Database
    {
        private String connetionString = @"Data Source=localhost;Initial Catalog=ExamWinForm;Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private String sqlString;
        private static readonly Database instance = new Database();

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
        public DataTable GetDataFromQuery(string query)
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
