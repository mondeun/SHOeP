using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shipping : IModel
    {
        public int ShippingId { get; set; }
        public string CompanyName { get; set; }
        public decimal Charge { get; set; }

        public void FromSqlReader(SqlDataReader reader)
        {
            if (!reader.HasRows) return;

            ShippingId = int.Parse(reader["ShippingId"].ToString());
            CompanyName = reader["CompanyName"].ToString();
            Charge = decimal.Parse(reader["Charge"].ToString());
        }
    }
}
