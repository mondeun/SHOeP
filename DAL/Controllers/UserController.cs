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

                var sql = $"INSERT INTO Customers (FirstName, LastName, Email, Phone, Address, Zip, City, Password, Salt) " +
                          $"VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Phone}', '{user.Address}', '{user.Zip}', '{user.City}', '{user.Password}', '{user.Salt}')";

                var cmd = new SqlCommand(sql, Connection.GetConnection());
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return result;
        }

        public User GetUserById(int id)
        {
            var user = new User();
            try
            {
                Connection.OpenConnection();

                var query = $"select * from Customers where CustomerId = '{id}'";
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

        public User GetUserByEmail(string email)
        {
            var user = new User();
            try
            {
                Connection.OpenConnection();

                var query = $"select * from Customers where CustomerId = '{email}'";
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

        public string GetSalt(string email)
        {
            var user = new User();
            try
            {
                Connection.OpenConnection();

                var query = $"select * from Customers where Email = '{email}'";
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
            return user.Salt;
        }

        public int UpdateUser(User user)
        {
            var result = 0;
            try
            {
                Connection.OpenConnection();

                var sql = "update Customers set " +
                          $"FirstName = '{user.FirstName}', " +
                          $"LastName = '{user.LastName}', " +
                          $"Email = '{user.Email}', " +
                          $"Phone = '{user.Phone}', " +
                          $"Address = '{user.Address}', " +
                          $"Zip = '{user.Zip}', " +
                          $"City = '{user.City}', " +
                          $"Password = '{user.Password}' " +
                          $"Salt = '{user.Salt}' " +
                          $"where CustomerId = '{user.UserId}'";

                var cmd = new SqlCommand(sql, Connection.GetConnection());
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return result;
        }

        public int DeleteUser(int id)
        {
            var result = 0;
            try
            {
                Connection.OpenConnection();

                var sql = $"delete from Customers where CustomerId = '{id}'";

                var cmd = new SqlCommand(sql, Connection.GetConnection());
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Connection.CloseConnection();
            }
            return result;
        }
    }
}
