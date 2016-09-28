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
    public partial class Women : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            NameValueCollection qscoll = HttpUtility.ParseQueryString(Page.ClientQueryString);

            string shoeType = qscoll.Get("ShoeType");
            foreach (ListItem item in DropDownList1.Items)
            {
                if (item.Text == shoeType)
                {
                    item.Selected = true;
                }
            }
        }

        public IQueryable<Model> GetModels([QueryString("ShoeType")] string shoeType)
        {
            List<Model> models = ModelController.GetModels(shoeType); // return List<Model>
            return models.AsQueryable<Model>();
        }

        public void Clicked(object sender, EventArgs e)
        {
            string ShoeType = DropDownList1.SelectedItem.Text;
            this.Response.Redirect(this.Request.Url.AbsoluteUri.Split('?')[0] + "?ShoeType=" + ShoeType, false);
        }
    }
}