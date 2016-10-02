using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Models;

namespace DAL.Controllers
{
    public class Controller
    {
        protected readonly DbConnection Connection;

        protected Controller()
        {
            Connection = new DbConnection();
        }


        protected static List<T> GetListFromQuery<T>(string query) where T : IModel, new()
        {
            List<T> list = new List<T>();
            SqlDataReader myDataReader = null;
            DbConnection conn = new DbConnection();

            try
            {
                conn.OpenConnection();
                SqlCommand myCommand = new SqlCommand(query, conn.GetConnection());
                myDataReader = myCommand.ExecuteReader();
                while (myDataReader.Read())
                {
                    T item = new T();
                    item.FromSqlReader(myDataReader);
                    list.Add(item);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Class: ModelController" + ex);
            }
            finally
            {
                myDataReader?.Close();
                conn.CloseConnection();
            }
            return list;
        }

        static protected List<string> GetColumnFromQuery(string query, string column)
        {
            List<string> list = new List<string>();
            SqlDataReader myDataReader = null;
            DbConnection conn = new DbConnection();

            try
            {
                conn.OpenConnection();
                SqlCommand myCommand = new SqlCommand(query, conn.GetConnection());
                myDataReader = myCommand.ExecuteReader();
                while (myDataReader.Read())
                {
                    string item = myDataReader[column].ToString();
                    list.Add(item);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Class: ModelController" + ex);
            }
            finally
            {
                myDataReader?.Close();
                conn.CloseConnection();
            }
            return list;
        }
    }
}
