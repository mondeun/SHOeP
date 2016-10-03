using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Controllers
{
    public class ShopingCartController : Controller
    {

        /*
            use SHOeP
            SELECT * FROM dbo.Models
            INNER JOIN dbo.Shoes ON dbo.Shoes.ModelId = dbo.Models.ModelId
            WHERE ShoeId = 1
         */

        public CartItem GetCartItem(int shoeId, int quantity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM dbo.Models");
            sb.Append(" INNER JOIN dbo.Shoes ON dbo.Shoes.ModelId = dbo.Models.ModelId");
            sb.Append(" WHERE ShoeId = " + shoeId);
            List<CartItem> list = GetListFromQuery<CartItem>(sb.ToString());
            if (list.Count > 0)
                list[0].Quantity = quantity;
            return list[0];
        }
    }
}
