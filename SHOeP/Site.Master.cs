using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Collections.Specialized;

namespace SHOeP
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user.Email"]!=null)
            {
                lblUserLogin.Text = "Welcome Back: " + Session["user.Email"].ToString();
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                lblUserLogin.Text = "";
                Panel2.Visible = false;
                Panel1.Visible = true;
            }
        }
    }
}