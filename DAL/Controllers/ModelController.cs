using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Models;

namespace DAL.Controllers
{
    public class ModelController
    {
        //private const string ConnectionString = "Data Source=.;Initial Catalog=SHOeP;Integrated Security=True";
        //Kriszta's local db
        private const string ConnectionString = "server=DESKTOP-QC3MALE\\SQLEXPRESS;Trusted_Connection=yes;database=SHOeP;connection timeout=10";

        private static List<T> GetListFromQuery<T>(string query) where T : SuperModel, new()
        {
            List<T> list = new List<T>();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataReader myDataReader = null;

            try
            {
                conn.Open();

                SqlCommand myCommand = new SqlCommand(query, conn);

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
                if (myDataReader != null)
                {
                    myDataReader.Close();
                }

                conn.Close();
            }
            return list;
        }


        public static List<Model> GetModels(string shoeType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM dbo.Models");
            if (shoeType != null && shoeType.Length > 0)
                sb.Append(" WHERE ShoeType = \'" + shoeType + "\'");
            return GetListFromQuery<Model>(sb.ToString());
        }

        public static List<Model> GetModel(int modelId)
        {
            return GetListFromQuery<Model>("SELECT * FROM dbo.Models WHERE ModelId = " + modelId);
        }
    }
}
