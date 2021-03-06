﻿using System;
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
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            NameValueCollection qscoll = HttpUtility.ParseQueryString(Page.ClientQueryString);

            string shoeType = qscoll.Get("ShoeType");
            foreach (ListItem item in ListBoxType.Items)
            {
                if (item.Text == shoeType)
                {
                    item.Selected = true;
                }
            }
            string size = qscoll.Get("Size");
            foreach (ListItem item in ListBoxSize.Items)
            {
                if (item.Text == size)
                {
                    item.Selected = true;
                }
            }
            string color = qscoll.Get("Color");
            foreach (ListItem item in ListBoxColor.Items)
            {
                if (item.Text == color)
                {
                    item.Selected = true;
                }
            }
            string priceSpan = qscoll.Get("PriceSpan");
            foreach (ListItem item in ListBoxPrice.Items)
            {
                if (item.Text == priceSpan)
                {
                    item.Selected = true;
                }
            }
        }

        public IQueryable<Model> GetModels([QueryString("ShoeType")] string shoeType,
                                                        [QueryString("Size")] string size,
                                                        [QueryString("Color")] string color,
                                                        [QueryString("PriceSpan")] string priceSpan,
                                                        [QueryString("Category")] string category)
        {
            IEnumerable<Model> models = new ModelController().GetModels(shoeType, size, color, priceSpan, category);
            return models.AsQueryable<Model>();
        }

        public void Clicked(object sender, EventArgs e)
        {
            string shoeType = ListBoxType.SelectedItem == null ? "Alla" : ListBoxType.SelectedItem.Text;
            string size = ListBoxSize.SelectedItem == null ? "Alla" : ListBoxSize.SelectedItem.Text;
            string color = ListBoxColor.SelectedItem == null ? "Alla" : ListBoxColor.SelectedItem.Text;
            string priceSpan = ListBoxPrice.SelectedItem == null ? "Alla" : ListBoxPrice.SelectedItem.Text;

            NameValueCollection qscoll = HttpUtility.ParseQueryString(Page.ClientQueryString);
            string category = qscoll.Get("Category");

            this.Response.Redirect(this.Request.Url.AbsoluteUri.Split('?')[0] + "?Category=" + category + "&ShoeType=" + 
                shoeType + "&Size=" + size + "&Color=" + color + "&PriceSpan=" + priceSpan, false);
        }
    }
}