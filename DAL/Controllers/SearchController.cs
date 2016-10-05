using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Controllers
{
    public class SearchController : Controller
    {
        public IEnumerable<Model> GetSearchResults(string search)
        {
            var sb = new StringBuilder();
            sb.Append("SELECT DISTINCT dbo.Models.ModelId, ModelName, Brand, Picture, Price, ShoeType, Material, Category, Description FROM dbo.Models");
            sb.Append(" INNER JOIN dbo.Shoes ON dbo.Shoes.ModelID = dbo.Models.ModelID");
            sb.Append(" INNER JOIN dbo.Stock ON dbo.Stock.ShoeId = dbo.Shoes.ShoeId");
            sb.Append($" WHERE Quantity > 0 AND ModelName LIKE @search OR Brand LIKE @search OR ShoeType LIKE @search");
            sb.Append($" OR Material LIKE search OR Category Like @search");

            var cmd = new SqlCommand(sb.ToString());

            var searchParam = new SqlParameter
            {
                ParameterName = "@search",
                Value = search
            };
            cmd.Parameters.Add(searchParam);

            return GetListFromQuery<Model>(cmd);
        }
    }
}
