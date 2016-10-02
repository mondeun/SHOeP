using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Controllers;
using DAL.Models;
using System.Collections;

namespace SHOeP.Order
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTotal.Text = "" + GetTotal();
        }

        public IQueryable<CartItem> GetShoppingCartItems()
        {
            string cartKey = "Cart";
            List<CartItem> cartItems = new List<CartItem>();
            Dictionary<int, int> cartSession;

            if (HttpContext.Current.Session[cartKey] != null)
            {
                //Key: shoeid, value: quantity
                cartSession = (Dictionary<int, int>)HttpContext.Current.Session[cartKey];

                foreach (KeyValuePair<int, int> cs in cartSession)
                {
                    cartItems.Add(ShopingCartController.GetCartItem(cs.Key, cs.Value));
                }
            }
            return cartItems.AsQueryable<CartItem>();
        }

        public decimal GetShoePrice(int shoeId)
        {
            return new ShoeController().GetShoePrice(shoeId);
        }

        public void QuantityPlusClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int shoeId = int.Parse(row.Cells[0].Text);

            string CartKey = "Cart";

            if (HttpContext.Current.Session[CartKey] == null)
            {
                HttpContext.Current.Session[CartKey] = new Dictionary<int, int>();
            }

            //Key: shoeid, value: quantity
            Dictionary<int, int> cartSession = (Dictionary<int, int>)HttpContext.Current.Session[CartKey];

            
            int inStock = new ShoeController().GetShoeQuantity(shoeId);
            int quantityToBuy = cartSession[shoeId] + 1;

            if (inStock >= quantityToBuy)
            {
                cartSession[shoeId] = quantityToBuy;
            }
            this.Response.Redirect(this.Request.Url.AbsoluteUri, false);
        }

        public void QuantityMinusClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int shoeId = int.Parse(row.Cells[0].Text);

            string CartKey = "Cart";

            if (HttpContext.Current.Session[CartKey] == null)
            {
                HttpContext.Current.Session[CartKey] = new Dictionary<int, int>();
            }

            //Key: shoeid, value: quantity
            Dictionary<int, int> cartSession = (Dictionary<int, int>)HttpContext.Current.Session[CartKey];

            if (cartSession.ContainsKey(shoeId))
            {
                if (cartSession[shoeId] == 1)
                {
                    cartSession.Remove(shoeId);
                }
                else
                {
                    cartSession[shoeId]--;
                }
            }

            this.Response.Redirect(this.Request.Url.AbsoluteUri, false);
        }

        public void RemoveClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;
            int shoeId = int.Parse(row.Cells[0].Text);

            string CartKey = "Cart";

            if (HttpContext.Current.Session[CartKey] == null)
            {
                HttpContext.Current.Session[CartKey] = new Dictionary<int, int>();
            }

            //Key: shoeid, value: quantity
            Dictionary<int, int> cartSession = (Dictionary<int, int>)HttpContext.Current.Session[CartKey];

            if (cartSession.ContainsKey(shoeId))
            {
                cartSession.Remove(shoeId);
            }

            this.Response.Redirect(this.Request.Url.AbsoluteUri, false);
        }

        public decimal GetTotal()
        {
            string CartKey = "Cart";
            if (HttpContext.Current.Session[CartKey] == null)
            {
                HttpContext.Current.Session[CartKey] = new Dictionary<int, int>();
            }
            Dictionary<int, int> cartSession = (Dictionary<int, int>)HttpContext.Current.Session[CartKey];

            decimal total = 0;
            foreach (KeyValuePair<int, int> p in cartSession)
            {
                total += GetShoePrice(p.Key) * p.Value;
            }

            return total;
        }

        public void ToOrderClick(object sender, EventArgs e)
        {

            //TODO: lägg till ett order
            //TODO: check inloggning
            //TODO: start transaction
            this.Response.Redirect("~/Order/OrderSummary.aspx", false);
        }
    }
}