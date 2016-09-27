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

        public static List<Model> GetModels()
        {
            List<Model> list = new List<Model>();
            SqlConnection conn = new SqlConnection(ConnectionString); ;
            SqlDataReader myDataReader = null; ;

            try
            {
                conn.Open();

                string sql = "SELECT * FROM dbo.Models";
                SqlCommand myCommand = new SqlCommand(sql, conn);

                myDataReader = myCommand.ExecuteReader();
                while (myDataReader.Read())
                {
                    list.Add(new Model(myDataReader));
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

                if (conn != null)
                {
                    conn.Close();
                }
            }
            return list;
        }
    }
}
