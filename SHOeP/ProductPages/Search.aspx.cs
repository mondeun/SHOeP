using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Controllers;
using DAL.Models;

namespace SHOeP.ProductPages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            var paramCollection = HttpUtility.ParseQueryString(Page.ClientQueryString);
            var search = paramCollection.Get("search");
        }

        public IQueryable<Model> GetModels([QueryString("search")] string search)
        {
            IEnumerable<Model> models = new SearchController().GetSearchResults(search);
            return models.AsQueryable<Model>();
        }
    }
}