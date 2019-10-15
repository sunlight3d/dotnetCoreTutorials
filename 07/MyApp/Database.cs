using System;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public sealed class Database
{

    private sealed String connetionString = @"Data Source=localhost;Initial Catalog=WinformExam;Integrated Security=True";
    private static readonly Database instance = new Database();
    private SqlConnection sqlConnection;
    private SqlCommand sqlCommand;
    private String sqlString;
    private SqlDataReader sqlDataReader;

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
            sqlConnection = new SqlConnection(instance.connetionString);
            sqlConnection.Open();
            return instance;
        }
    }
    public Boolean login(String UserName, String Password)
    {
        sqlCommand.Parameters.AddWithValue("@UserName", UserName);
        sqlCommand.Parameters.AddWithValue("@Password", Password);
        sqlString = "SELECT StudentCode from tblStudent " +
                    "WHERE UserName = @UserName AND Password = @Password";
        while (sqlDataReader.Read())
        {
            return true;
        }
        return false;
    }
}
