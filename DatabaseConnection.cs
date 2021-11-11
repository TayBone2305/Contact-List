using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Contact_List
{
    public class DatabaseConnection
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        private static readonly DatabaseConnection dbConnectInstance = new DatabaseConnection();

        private DatabaseConnection() { }

        public static DatabaseConnection DbConnectInstance
        {
            get
            {
                return dbConnectInstance;
            }
        }

        public void BuildConnection(string sqlQuery)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["tayfun_dbConnectionString"].ToString();
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
        }

        public DataSet CreateDataSetAndAdapter()
        {
            var dataSet = new DataSet();
            var sqlDataAdapter = new SqlDataAdapter(this.GetSqlCommand());
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }

        public SqlCommand GetSqlCommand()
        {
            return sqlCommand;
        }
    }
}