using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
        public string Salt { get; set; }

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

        private void CreateSalt()
        {
            var rng = RandomNumberGenerator.Create();
            var bytes = new byte[10];
            rng.GetBytes(bytes);
            Salt = Convert.ToBase64String(bytes);
        }

        public void HashAndSaltPassword()
        {
            CreateSalt();
            var bytes = Encoding.UTF8.GetBytes(Salt + Password);
            var hashstring = new SHA256Managed();
            Password = Convert.ToBase64String(hashstring.ComputeHash(bytes));
        }

        public void GenerateNewPassword()
        {
            var rng = RandomNumberGenerator.Create();
            var bytes = new byte[10];
            rng.GetBytes(bytes);
            Password = Convert.ToBase64String(bytes);
        }

        public static string Hash(string salt, string password)
        {
            var bytes = Encoding.UTF8.GetBytes(salt + password);
            var hashstring = new SHA256Managed();
            return Convert.ToBase64String(hashstring.ComputeHash(bytes));
        }
    }
}
