using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Controllers
{
    public class ShippingController : Controller
    {
        public List<Shipping> GetAllShipping()
        {
            return GetListFromQuery<Shipping>("SELECT * FROM dbo.Shipping");
        }

        public int GetShippingId(string companyName)
        {
            string query = "SELECT ShippingId FROM dbo.Shipping WHERE CompanyName = '" + companyName + "'";
            return int.Parse(GetColumnFromQuery(query, "ShippingId")[0]);
        }
    }
}
