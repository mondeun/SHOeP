using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order : IModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public int ShippingId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        public void FromSqlReader(SqlDataReader reader)
        {
            if (!reader.HasRows) return;

            OrderId = int.Parse(reader["OrderId"].ToString());
            OrderNumber = reader["OrderNumber"].ToString();
            CustomerId = int.Parse(reader["CustomerId"].ToString());
            ShippingId = int.Parse(reader["ShippingId"].ToString());
            OrderDate = DateTime.Parse(reader["OrderDate"].ToString());
            DeliveryDate = DateTime.Parse(reader["DeliveryDate"].ToString());
            TotalPrice = decimal.Parse(reader["TotalPrice"].ToString());
            Status = reader["Status"].ToString();
        }
    }
}
