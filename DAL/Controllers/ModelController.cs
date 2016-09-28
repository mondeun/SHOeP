using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Models;

namespace DAL.Controllers
{
    public class ModelController : Controller
    {
        //Kriszta's local db
        //private const string ConnectionString = "server=DESKTOP-QC3MALE\\SQLEXPRESS;Trusted_Connection=yes;database=SHOeP;connection timeout=10";

        private List<T> GetListFromQuery<T>(string query) where T : IModel, new()
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
                if (myDataReader != null)
                {
                    myDataReader.Close();
                }

                Connection.CloseConnection();
            }
            return list;
        }


        public IEnumerable<Model> GetModels(string shoeType, string size, string color, string priceSpan)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT DISTINCT dbo.Models.ModelId, ModelName, Brand, Picture, Price, ShoeType, Material, Category, Description FROM dbo.Models");
            sb.Append(" JOIN dbo.Shoes ON dbo.Shoes.ModelID = dbo.Models.ModelID");

            bool firstWhere = true;

            /*
             *  SELECT * FROM dbo.Models
             *  JOIN dbo.Shoes ON dbo.Shoes.ModelID = dbo.Models.ModelID
             *  WHERE ShoeType = shoeType
             */

            if (!string.IsNullOrEmpty(size) && size != "Alla")
            {
                sb.Append(" WHERE Size = " + size);
                firstWhere = false;
            }
            if (!string.IsNullOrEmpty(shoeType) && shoeType != "Alla")
            {
                sb.Append(firstWhere ? " WHERE" : " AND");
                sb.Append(" ShoeType = \'" + shoeType + "\'");
                firstWhere = false;
            }
            if (!string.IsNullOrEmpty(color) && color != "Alla")
            {
                sb.Append(firstWhere ? " WHERE" : " AND");
                sb.Append(" Color = \'" + color + "\'");
                firstWhere = false;
            }
            if (!string.IsNullOrEmpty(priceSpan) && priceSpan != "Alla")
            {
                string low = priceSpan.Split('-')[0];
                string high = priceSpan.Split('-')[1];
                sb.Append(firstWhere ? " WHERE" : " AND");
                sb.Append(" Price >= " + low + " AND Price <= " + high);
                firstWhere = false;
            }

            return GetListFromQuery<Model>(sb.ToString());
        }

        public IEnumerable<Model> GetModel(int modelId)
        {
            return GetListFromQuery<Model>("SELECT * FROM dbo.Models WHERE ModelId = " + modelId);
        }
    }
}
