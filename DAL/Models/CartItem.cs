using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CartItem : IModel
    {
        public int ShoeId { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName => Brand + ", " + ModelName;

        public void FromSqlReader(SqlDataReader reader)
        {
            if (!reader.HasRows) return;

            ShoeId = int.Parse(reader["ShoeId"].ToString());
            Brand = reader["Brand"].ToString();
            ModelName = reader["ModelName"].ToString();
            Color = reader["Color"].ToString();
            Size = int.Parse(reader["Size"].ToString());
            UnitPrice = decimal.Parse(reader["Price"].ToString());
        }
    }
}
