using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Models;
using DAL.Controllers;
using System.Web.ModelBinding;

namespace SHOeP.ProductPages
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Model> GetModel([QueryString("modelID")] int? modelId)
        {
            if (!modelId.HasValue)
            {
                return null;
            }

            List<Model> models = ModelController.GetModel(modelId.Value);
            return models.AsQueryable<Model>();
        }
    }
}