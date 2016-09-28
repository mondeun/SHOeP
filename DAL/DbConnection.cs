using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DbConnection
    {
        private readonly SqlConnection _connection;

        private const string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SHOeP.mdf;Initial Catalog=DatabaseName;Integrated Security=True";

        //Kriszta's local db
        //private const string ConnectionString = "server=DESKTOP-QC3MALE\\SQLEXPRESS;Trusted_Connection=yes;database=SHOeP;connection timeout=10";

        internal DbConnection()
        {
            _connection = new SqlConnection(ConnectionString);
        }

        internal SqlConnection GetConnection() => _connection;

        internal void OpenConnection()
        {
            _connection.Open();
        }

        internal void CloseConnection()
        {
            _connection.Close();
        }
    }
}
