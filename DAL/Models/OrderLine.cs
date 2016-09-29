using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderLine : IModel
    {
        public int OrderId { get; set; }
        public int ShoeId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }

        public void FromSqlReader(SqlDataReader reader)
        {
            if (!reader.HasRows) return;

            OrderId = int.Parse(reader["OrderId"].ToString());
            ShoeId = int.Parse(reader["ShoeId"].ToString());
            Quantity = int.Parse(reader["Quantity"].ToString());
            Amount = decimal.Parse(reader["Amount"].ToString());
            Discount = decimal.Parse(reader["Discount"].ToString());
        }
    }
}
