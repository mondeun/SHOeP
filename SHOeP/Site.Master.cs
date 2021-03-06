﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Collections.Specialized;
using DAL.Controllers;
using DAL.Models;

namespace SHOeP
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                var user = (User)Session["user"];
                lblUser.Text = user.FirstName;
                Pout.Visible = true;
                PlogReg.Visible = false;
            }
            else
            {
                PlogReg.Visible = true;
                Pout.Visible = false;
            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
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
                total += p.Value;
            }
            cartCount.Text = total.ToString();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = Server.UrlEncode(txtSearchMaster.Text); // URL encode in case of special characters
            Response.Redirect("~/ProductPages/Search.aspx?search=" + searchText);
        }
    }
}