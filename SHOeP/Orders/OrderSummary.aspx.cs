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
        public enum AddressKeeper { address, city , zip }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            lblTotal.Text = "" + GetTotal();

            User logUser = (User)HttpContext.Current.Session["user"];
            if (logUser != null)
            {
                Name.Text = logUser.FirstName + " " + logUser.LastName;
                Adress.Text = logUser.Address;
                CityZip.Text = logUser.City + " " + logUser.Zip;


                ShippingController sc = new ShippingController();
                List<Shipping> delivery = sc.GetAllShipping();
                foreach (Shipping s in delivery)
                {
                    DeliveryMode.Items.Add(s.CompanyName + "\t" + s.Charge + " kr frakt");
                }

                DeliveryMode.SelectedIndex = 0;
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
            this.Response.Redirect("~/Orders/ShoppingCart.aspx", false);
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
            order.DeliveryDate = DateTime.Today.AddDays(4.0); 
            order.OrderDate = DateTime.Today;
            order.OrderNumber = generateOrderNumber();
            ShippingController sc = new ShippingController();
            string companyName = DeliveryMode.SelectedItem.Text.Split('\t')[0];
            order.ShippingId = sc.GetShippingId(companyName);
            order.TotalPrice = GetTotal() + sc.GetShippingById(order.ShippingId);
            order.Status = null;

            bool ok  = new OrderController().Transaction(ref order, cartSession);

            if (ok)
            {
                string deliver = companyName;
                //Save "DeliveryMode" to session
                HttpContext.Current.Session["DeliveryMode"] = order.ShippingId;
                HttpContext.Current.Session["LastOrder"] = order;

                Dictionary<AddressKeeper, string> deliveryAddress = new Dictionary<AddressKeeper, string>();
                if (levaddressBox.Text.Count() > 0 && levcityBox.Text.Count() > 0 && levzipBox.Text.Count() > 0)
                {
                    deliveryAddress[AddressKeeper.address] = levaddressBox.Text;
                    deliveryAddress[AddressKeeper.city] = levcityBox.Text;
                    deliveryAddress[AddressKeeper.zip] = levzipBox.Text;
                } else
                {
                    deliveryAddress[AddressKeeper.address] = logUser.Address;
                    deliveryAddress[AddressKeeper.city] = logUser.City;
                    deliveryAddress[AddressKeeper.zip] = logUser.Zip;
                }

                //Save "DeliveryInfo" to session
                HttpContext.Current.Session["DeliveryInfo"] = deliveryAddress;


                this.Response.Redirect("~/Orders/OrderConfirmation.aspx", false);
            }
            else
            {
                this.Response.Redirect("Default.aspx", false);
            }
        }

        private string generateOrderNumber()
        {
            System.Random rnd = new Random((int)DateTime.Now.Ticks);
            string randomStr = String.Empty;
            for (int i = 0; i < 3; i++)
            {
                int tmp = rnd.Next(1000, 9999);
                randomStr += tmp.ToString();
            }
            return randomStr;
        }

    }
}