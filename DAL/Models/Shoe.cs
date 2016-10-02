using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shoe : IModel
    {
        public int ShoeId { get; set; }
        public int ModelId { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }

        public void FromSqlReader(SqlDataReader reader)
        {
            if (!reader.HasRows) return;

            ShoeId = int.Parse(reader["ShoeId"].ToString());
            ModelId = int.Parse(reader["ModelId"].ToString());
            Color = reader["Color"].ToString();
            Size = int.Parse(reader["Size"].ToString());
        }
    }
}
