﻿using System;
using System.Collections.Generic;
using System.Data;
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
        public void insertStudent(String studentName, int gender,
            DateTime dateOfBirth, String address, String classCode, 
            String userName, String password)
        {

            sqlString = "INSERT INTO tblStudent" +
                "(StudentName, Gender, DateOfBirth, Address, ClassCode, UserName, Password)" +
                "VALUES(@StudentName, @Gender, @DateOfBirth, @Address, @ClassCode, @UserName, @Password)";
            sqlCommand = new SqlCommand(sqlString, Connection);
            sqlCommand.Parameters.AddWithValue("@StudentName", studentName);
            sqlCommand.Parameters.AddWithValue("@Gender", gender);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Address", address);
            sqlCommand.Parameters.AddWithValue("@ClassCode", classCode);
            sqlCommand.Parameters.AddWithValue("@UserName", userName);
            sqlCommand.Parameters.AddWithValue("@Password", password);
            int affectedRows = sqlCommand.ExecuteNonQuery();
        }
        public DataTable fetchDataTable() 
        {
            sqlString = "SELECT ClassName, StudentName," +
                "UserName, Address FROM tblClass " +
                "INNER JOIN tblStudent " +
                "ON tblClass.ClassCode = tblStudent.ClassCode " +
                "ORDER BY tblClass.ClassName";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlString, Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
