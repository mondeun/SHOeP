using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;

namespace SHOeP.ProductPages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
        }

        public IEnumerable<Model> GetModels()
        {
            throw new NotImplementedException();
        }
    }
}