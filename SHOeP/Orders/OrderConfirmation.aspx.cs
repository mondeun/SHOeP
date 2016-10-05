using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHOeP.Orders
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void HomeClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx", false);
        }
    }
}