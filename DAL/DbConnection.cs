using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbConnection
    {
        private readonly SqlConnection _connection;
        private string _connectionString;

        public DbConnection()
        {
            _connectionString = "Data Source=.;Initial Catalog=SHOeP;Integrated Security=True";
            _connection = new SqlConnection(_connectionString);
        }

        public SqlConnection GetConnection() => _connection;

        public void OpenConnection()
        {
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
