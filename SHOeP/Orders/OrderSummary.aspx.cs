using DAL.Controllers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHOeP.Orders
{
    public partial class OrderSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTotal.Text = "" + GetTotal();

            User logUser = (User)HttpContext.Current.Session["user"];
            if (logUser != null)
            {
                //TODO - test when login works properly
                Name.Text = logUser.FirstName + " " + logUser.LastName;
                Adress.Text = logUser.Address;
                CityZip.Text = logUser.City + " " + logUser.Zip;
            }

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
                    cartItems.Add(new ShopingCartController().GetCartItem(cs.Key, cs.Value));
                }
            }
            return cartItems.AsQueryable<CartItem>();
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

        public decimal GetShoePrice(int shoeId)
        {
            return new ShoeController().GetShoePrice(shoeId);
        }

        public void CancelClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Order/ShoppingCart.aspx", false);
        }

        public void ConfirmationClick(object sender, EventArgs e)
        {
            string CartKey = "Cart";
            if (HttpContext.Current.Session[CartKey] == null)
            {
                HttpContext.Current.Session[CartKey] = new Dictionary<int, int>();
            }
            Dictionary<int, int> cartSession = (Dictionary<int, int>)HttpContext.Current.Session[CartKey];
            User logUser = (User)Session["user"];

            Order order = new Order();
            order.CustomerId = logUser.UserId;
            order.TotalPrice = GetTotal();
            order.DeliveryDate = DateTime.Today.AddDays(1.0); 
            order.OrderDate = DateTime.Today; ;
            order.OrderNumber = "123456789012"; //TODO
            order.ShippingId = 1; //TODO slumpa?
            order.Status = null; //TTOD ?

            string cartKey = "Cart";

            bool ok  = new OrderController().Transaction(order, cartSession);

            if (ok)
            {
                HttpContext.Current.Session[cartKey] = null;
                this.Response.Redirect("~/Orders/OrderConfirmation.aspx", false);
            }

            //TODO Order misslyckades
        }

    }
}