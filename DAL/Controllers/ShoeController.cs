using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Controllers
{
    public class ShoeController : Controller
    {
        public IEnumerable<String> GetShoeColors(int modelId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT DISTINCT Color FROM dbo.Models");
            sb.Append(" INNER JOIN dbo.Shoes ON dbo.Shoes.ModelId = dbo.Models.ModelId");
            sb.Append(" INNER JOIN dbo.Stock ON dbo.Stock.ShoeId = dbo.Shoes.ShoeId");
            sb.Append(" WHERE Models.ModelId = " + modelId);
            sb.Append(" AND Quantity > 0");

            return GetColumnFromQuery(sb.ToString(), "Color");
        }

        public IEnumerable<String> GetShoeSizesForColor(int modelId, string color)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT DISTINCT Size FROM dbo.Models");
            sb.Append(" INNER JOIN dbo.Shoes ON dbo.Shoes.ModelId = dbo.Models.ModelId");
            sb.Append(" INNER JOIN dbo.Stock ON dbo.Stock.ShoeId = dbo.Shoes.ShoeId");
            sb.Append(" WHERE Models.ModelId = " + modelId);
            sb.Append(" AND Quantity > 0");
            sb.Append(" AND Color = \'" + color + "\'");
            sb.Append(" ORDER BY Size");

            return GetColumnFromQuery(sb.ToString(), "Size");
        }

        /*
         *  
            SELECT Size FROM dbo.Models
            INNER JOIN dbo.Shoes ON dbo.Shoes.ModelId = dbo.Models.ModelId
            INNER JOIN dbo.Stock ON dbo.Stock.ShoeId = dbo.Shoes.ShoeId
            WHERE Models.ModelId = 4
            AND Color = 'Red'
            AND Quantity > 0
            ORDER BY Size
         */

        public IEnumerable<Shoe> GetShoe(int modelId, string color, string size)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM dbo.Models");
            sb.Append(" INNER JOIN dbo.Shoes ON dbo.Shoes.ModelId = dbo.Models.ModelId");
            sb.Append(" INNER JOIN dbo.Stock ON dbo.Stock.ShoeId = dbo.Shoes.ShoeId");
            sb.Append(" WHERE Models.ModelId = " + modelId);
            sb.Append(" AND Color = \'" + color + "\'");
            sb.Append(" AND Size = " + size);

            return GetListFromQuery<Shoe>(sb.ToString());
        }

        public decimal GetShoePrice(int shoeId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM dbo.Models");
            sb.Append(" INNER JOIN dbo.Shoes ON dbo.Shoes.ModelId = dbo.Models.ModelId");
            sb.Append(" WHERE Shoes.ShoeId = " + shoeId);

            return decimal.Parse(GetColumnFromQuery(sb.ToString(), "Price")[0]);
        }

        public int GetShoeQuantity(int shoeId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Quantity FROM dbo.Shoes");
            sb.Append(" INNER JOIN dbo.Stock ON dbo.Stock.ShoeId = dbo.Shoes.ShoeId");
            sb.Append(" WHERE Shoes.ShoeId = " + shoeId);

            return int.Parse(GetColumnFromQuery(sb.ToString(), "Quantity")[0]);
        }

    }
}
