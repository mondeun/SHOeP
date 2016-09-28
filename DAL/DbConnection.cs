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
        private const string ConnectionString = "Data Source=.;Initial Catalog=SHOeP;Integrated Security=True";
        
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
