using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using DAL.Controllers;

namespace SHOeP.ProductPages
{
    public partial class Women : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //The method that is called by samename.aspx
        public IQueryable<Model> GetModels()
        {
            List<Model> models = ModelController.GetModels(); // return List<Model>
            return models.AsQueryable<Model>();

        }
    }
}