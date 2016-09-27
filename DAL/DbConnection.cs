using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class DbConnection
    {
        private readonly SqlConnection _connection;
        private const string ConnectionString = "Data Source=.;Initial Catalog=SHOeP;Integrated Security=True";
        //Kriszta's local db
        //private const string ConnectionString = "server=DESKTOP-QC3MALE\\SQLEXPRESS;Trusted_Connection=yes;database=SHOeP;connection timeout=10";

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

        public static List<Model> GetModels()
        {
            List<Model> list = new List<Model>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM dbo.Models";
                SqlCommand myCommand = new SqlCommand(sql, conn);

                SqlDataReader myDataReader = myCommand.ExecuteReader();
                while (myDataReader.Read())
                {
                    list.Add(new Model(myDataReader));
                }
            }
            return list;
        }
    }
}
