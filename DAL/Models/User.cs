using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User : IModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Password { get; set; }

        public void FromSqlReader(SqlDataReader reader)
        {
            if (!reader.HasRows) return;

            UserId = int.Parse(reader["CustomerId"].ToString());
            FirstName = reader["FirstName"].ToString();
            LastName = reader["LastName"].ToString();
            Email = reader["Email"].ToString();
            Phone = reader["Phone"].ToString();
            Address = reader["Address"].ToString();
            Zip = reader["Zip"].ToString();
            City = reader["City"].ToString();
            Password = reader["Password"].ToString();
        }
    }
}
