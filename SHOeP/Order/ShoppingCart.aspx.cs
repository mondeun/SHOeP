using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHOeP.Order
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartController actions = new ShoppingCartController();
            return actions.GetCartItems();
        }
    }
}