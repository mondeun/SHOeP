using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Stock : IModel
    {
        public int ShoeId { get; set; }
        public int Quantity { get; set; }
        public DateTime QuantityChangedDate { get; set; }

        public void FromSqlReader(SqlDataReader reader)
        {
            if (!reader.HasRows) return;

            ShoeId = int.Parse(reader["StockId"].ToString());
            Quantity = int.Parse(reader["Quantity"].ToString());
            QuantityChangedDate = DateTime.Parse(reader["QuantityChangedDate"].ToString());
        }
    }
}
