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

        public decimal GetShippingByCoName(string companyName)
        {
            string query = $"select Charge from dbo.Shipping where CompanyName = '{companyName}'";
            return decimal.Parse(GetColumnFromQuery(query, "CompanyName")[0]);
        }

        public string GetShippingCo(int shippingId)
        {
            string query = $"select CompanyName from dbo.Shipping where ShippingId = '{shippingId}'";
            return GetColumnFromQuery(query, "CompanyName")[0];
        }

        public decimal GetShippingById(int shippingId)
        {
            string query = $"select Charge from dbo.Shipping where ShippingId = '{shippingId}'";
            return decimal.Parse(GetColumnFromQuery(query, "Charge")[0]);
        }
    }
}
