using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using DAL.Controllers;
using System.Web.ModelBinding;
using System.Collections.Specialized;

namespace SHOeP.ProductPages
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            NameValueCollection qscoll = HttpUtility.ParseQueryString(Page.ClientQueryString);
            string modelID = qscoll.Get("modelID");
            string wasInStock = qscoll.Get("InStock");



            RadioButtonList RadioButtonColor = (RadioButtonList)FormView2.FindControl("RadioButtonColor");
            RadioButtonList RadioButtonSize = (RadioButtonList)FormView2.FindControl("RadioButtonSize");

            if (wasInStock == "false")
            {
                OutOfStock.Text = "Tyvärr, det finns inte fler i lagret.";
            }

            IQueryable<String> shoesColor = GetShoeColors(int.Parse(modelID)); // TODO: try-catch
            foreach (String c in shoesColor)
            {
                RadioButtonColor.Items.Add(c);
            }
            RadioButtonColor.SelectedIndex = 0;

            string color = qscoll.Get("Color");
            foreach (ListItem item in RadioButtonColor.Items)
            {
                if (item.Text == color)
                {
                    item.Selected = true;
                }
            }

            IQueryable<String> shoesSize = GetShoeSizesForColor(int.Parse(modelID), RadioButtonColor.SelectedItem.Text); // TODO: try-catch
            foreach (String s in shoesSize)
            {
                RadioButtonSize.Items.Add(s);
            }
            RadioButtonSize.SelectedIndex = 0;

            string size = qscoll.Get("Size");
            foreach (ListItem item in RadioButtonSize.Items)
            {
                if (item.Text == size)
                {
                    item.Selected = true;
                }
            }
        }

        public IQueryable<Model> GetModel([QueryString("modelID")] int? modelId)
        {
            if (!modelId.HasValue)
            {
                return null;
            }

            IEnumerable<Model> models = new ModelController().GetModel(modelId.Value);
            return models.AsQueryable<Model>();
        }

        public IQueryable<String> GetShoeColors([QueryString("modelID")] int? modelId)
        {
            if (!modelId.HasValue)
            {
                return null;
            }

            IEnumerable<String> shoes = new ShoeController().GetShoeColors(modelId.Value);
            return shoes.AsQueryable<String>();
        }

        public IQueryable<String> GetShoeSizesForColor([QueryString("modelID")] int? modelId, [QueryString("Color")] string color)
        {
            if (!modelId.HasValue || color == null)
            {
                return null;
            }

            IEnumerable<String> shoes = new ShoeController().GetShoeSizesForColor(modelId.Value, color);
            return shoes.AsQueryable<String>();
        }

        public IQueryable<Shoe> GetShoe([QueryString("modelID")] int? modelId, [QueryString("color")] string color, [QueryString("size")] string size)
        {
            if (!modelId.HasValue || color == null || size == null)
            {
                return null;
            }

            IEnumerable<Shoe> shoe = new ShoeController().GetShoe(modelId.Value, color, size);
            return shoe.AsQueryable<Shoe>();
        }

        public void Clicked(object sender, EventArgs e)
        {
            RadioButtonList RadioButtonColor = (RadioButtonList)FormView2.FindControl("RadioButtonColor");
            RadioButtonList RadioButtonSize = (RadioButtonList)FormView2.FindControl("RadioButtonSize");

            string color = RadioButtonColor.SelectedItem.Text;
            string size = RadioButtonSize.SelectedItem.Text;

            NameValueCollection qscoll = HttpUtility.ParseQueryString(Page.ClientQueryString);
            string modelID = qscoll.Get("modelID");

            this.Response.Redirect(this.Request.Url.AbsoluteUri.Split('?')[0] + "?modelID=" + modelID +
                "&Size=" + size + "&Color=" + color, false);
        }

        public void AddToCartClick(object sender, EventArgs e)
        {
            RadioButtonList RadioButtonColor = (RadioButtonList)FormView2.FindControl("RadioButtonColor");
            RadioButtonList RadioButtonSize = (RadioButtonList)FormView2.FindControl("RadioButtonSize");

            NameValueCollection qscoll = HttpUtility.ParseQueryString(Page.ClientQueryString);
            string modelID = qscoll.Get("modelID");

            IQueryable<Shoe> shoe = GetShoe(int.Parse(modelID), RadioButtonColor.Text, RadioButtonSize.Text); // TODO: try-catch
            int shoeId = shoe.First().ShoeId;

            string CartKey = "Cart";
            if (HttpContext.Current.Session[CartKey] == null)
            {
                HttpContext.Current.Session[CartKey] = new Dictionary<int, int>();
            }
            Dictionary<int, int> cartSession = (Dictionary<int, int>)HttpContext.Current.Session[CartKey];

            int inStock = new ShoeController().GetShoeQuantity(shoeId);
            int quantityToBuy = cartSession.ContainsKey(shoeId) ? cartSession[shoeId] + 1: 1;

            bool allowed = true;
            if (inStock < quantityToBuy)
            {
                allowed = false;
                OutOfStock.Text = "Tyvärr, produkten tog slut i lagret.";
            }
            else
            {
                cartSession[shoeId] = quantityToBuy;
            }

            this.Response.Redirect(this.Request.Url.AbsoluteUri.Split('?')[0] + "?modelID=" + modelID +
                (allowed ? "" : "&InStock=false"), false);
        }

        public void ToShoppingCartClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Order/ShoppingCart.aspx", false);
        }



    }
}