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
        private const string ConnectionString = "Data Source=.;Initial Catalog=SHOeP;Integrated Security=True";

        public DbConnection()
        {
            _connection = new SqlConnection(ConnectionString);
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
