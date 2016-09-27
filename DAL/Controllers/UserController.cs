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

                var sql = $"insert into customers (FirstName, LastName, Email, Phone, Address, Zip, City, Password) " +
                          $"values ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Phone}', '{user.Address}', '{user.Zip}', '{user.City}', '{user.Password}')";

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
            throw new NotImplementedException();
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
