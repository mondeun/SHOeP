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


        protected List<T> GetListFromQuery<T>(string query) where T : IModel, new()
        {
            List<T> list = new List<T>();
            SqlDataReader myDataReader = null;

            try
            {
                Connection.OpenConnection();
                SqlCommand myCommand = new SqlCommand(query, Connection.GetConnection());
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
                Connection.CloseConnection();
            }
            return list;
        }

        protected List<string> GetColumnFromQuery(string query, string column)
        {
            List<string> list = new List<string>();
            SqlDataReader myDataReader = null;

            try
            {
                Connection.OpenConnection();
                SqlCommand myCommand = new SqlCommand(query, Connection.GetConnection());
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
                Connection.CloseConnection();
            }
            return list;
        }

        protected int InsertToDatabase(string insert)
        {
            var result = 0;
            try
            {
                Connection.OpenConnection();
                var cmd = new SqlCommand(insert, Connection.GetConnection());
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return result;
        }
    }
}
