using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Models
{
    public class Model : SuperModel
    {
        public int ModelId { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string Material { get; set; }
        public string Category { get; set; }
        public string ShoeType { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public override void FromSqlReader(SqlDataReader reader)
        {
            ModelId = int.Parse(reader["ModelId"].ToString());
            Brand = reader["Brand"].ToString();
            ModelName = reader["ModelName"].ToString();
            Material = reader["Material"].ToString();
            Category = reader["Category"].ToString();
            ShoeType = reader["ShoeType"].ToString();
            Picture = reader["Picture"].ToString();
            Description = reader["Description"].ToString();
            Price = decimal.Parse(reader["Price"].ToString());
        }
    }
}
