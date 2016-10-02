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
        public IEnumerable<Model> GetModels(string shoeType, string size, string color, string priceSpan, string category)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT DISTINCT dbo.Models.ModelId, ModelName, Brand, Picture, Price, ShoeType, Material, Category, Description FROM dbo.Models");
            sb.Append(" JOIN dbo.Shoes ON dbo.Shoes.ModelID = dbo.Models.ModelID");

            List<String> where = new List<String>();

            /*
             *  SELECT * FROM dbo.Models
             *  JOIN dbo.Shoes ON dbo.Shoes.ModelID = dbo.Models.ModelID
             *  WHERE ShoeType = shoeType
             */
            if (!string.IsNullOrEmpty(category))
            {
                where.Add(" Category = \'" + category + "\'");
            }
            if (!string.IsNullOrEmpty(size) && size != "Alla")
            {
                where.Add(" Size = " + size);
            }
            if (!string.IsNullOrEmpty(shoeType) && shoeType != "Alla")
            {
                where.Add(" ShoeType = \'" + shoeType + "\'");
            }
            if (!string.IsNullOrEmpty(color) && color != "Alla")
            {
                where.Add(" Color = \'" + color + "\'");
            }
            if (!string.IsNullOrEmpty(priceSpan) && priceSpan != "Alla")
            {
                string low = priceSpan.Split('-')[0];
                string high = priceSpan.Split('-')[1];
                where.Add(" Price BETWEEN " + low + " AND " + high);
            }

            if (where.Count > 0)
                sb.Append(" WHERE");
            sb.Append(string.Join(" AND", where));

            return GetListFromQuery<Model>(sb.ToString());
        }

        public IEnumerable<Model> GetModel(int modelId)
        {
            return GetListFromQuery<Model>("SELECT * FROM dbo.Models WHERE ModelId = " + modelId);
        }
    }
}
