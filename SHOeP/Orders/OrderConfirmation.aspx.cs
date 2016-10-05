using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Controllers;
using DAL.Models;

namespace SHOeP.Orders
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            lblTotal.Text = "" + GetTotal();

            User logUser = (User)HttpContext.Current.Session["user"];
            Dictionary<OrderSummary.AddressKeeper, string> deliveryAddress = (Dictionary<OrderSummary.AddressKeeper, string>) HttpContext.Current.Session["DeliveryInfo"];
            int delivery = (int) HttpContext.Current.Session["DeliveryMode"];
            Order lastOrder = (Order) HttpContext.Current.Session["LastOrder"];

            if (logUser != null && deliveryAddress != null)
            {
                Name.Text = logUser.FirstName + " " + logUser.LastName;
                Adress.Text = deliveryAddress[OrderSummary.AddressKeeper.address];
                CityZip.Text = deliveryAddress[OrderSummary.AddressKeeper.city] + " " + deliveryAddress[OrderSummary.AddressKeeper.zip];
            }
            OrderNumber.Text = lastOrder.OrderNumber;

            lblTotal.Text = GetTotal().ToString();

            ShippingController sc = new ShippingController();
            DeliveryMode.Text = sc.GetShippingCo(delivery).ToString();
            DeliveryCharge.Text = sc.GetShippingById(delivery).ToString();

            TotalPayment.Text = lastOrder.TotalPrice.ToString();

            HttpContext.Current.Session["DeliveryInfo"] = null;
            HttpContext.Current.Session["DeliveryMode"] = null;
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

            IQueryable<CartItem> tmp = cartItems.AsQueryable<CartItem>();

            HttpContext.Current.Session[cartKey] = null;
            return tmp;
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


        public void HomeClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx", false);
        }
    }
}