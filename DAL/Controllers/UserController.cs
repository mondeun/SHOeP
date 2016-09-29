using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Controllers
{
    public class UserController : Controller
    {
        public int AddUser(User user)
        {
            var result = 0;
            try
            {
                Connection.OpenConnection();

                var sql = $"INSERT INTO Customers (FirstName, LastName, Email, Phone, Address, Zip, City, Password) " +
                          $"VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Phone}', '{user.Address}', '{user.Zip}', '{user.City}', '{user.Password}')";

                var cmd = new SqlCommand(sql, Connection.GetConnection());
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                Connection.CloseConnection();
            }
            return result;
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLoginCredentials(string email, string password)
        {
            var user = new User();
            try
            {
                Connection.OpenConnection();

                var query = $"select * from Customers where Email = '{email}' and Password = '{password}'";
                var cmd = new SqlCommand(query, Connection.GetConnection());

                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    user.FromSqlReader(reader);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return user;
        }

        public int UpdateUser(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
