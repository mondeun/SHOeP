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
                var sql = "INSERT INTO Customers (FirstName, LastName, Email, Phone, Address, Zip, City, Password, Salt) " +
                          "VALUES (@firstName, @lastName, @email, @phone, @address, @zip, @city, @password, @salt)";

                var firstNameParam = new SqlParameter()
                {
                    ParameterName = "@firstName",
                    Value = user.FirstName
                };
                var lastNameParam = new SqlParameter()
                {
                    ParameterName = "@lastName",
                    Value = user.LastName
                };
                var emailParam = new SqlParameter()
                {
                    ParameterName = "@email",
                    Value = user.Email
                };
                var phoneParam = new SqlParameter()
                {
                    ParameterName = "@phone",
                    Value = user.Phone
                };
                var addressParam = new SqlParameter()
                {
                    ParameterName = "@address",
                    Value = user.Address
                };
                var zipParam = new SqlParameter()
                {
                    ParameterName = "@zip",
                    Value = user.Zip
                };
                var cityParam = new SqlParameter()
                {
                    ParameterName = "@city",
                    Value = user.City
                };
                var passwordParam = new SqlParameter()
                {
                    ParameterName = "@password",
                    Value = user.Password
                };
                var saltParam = new SqlParameter()
                {
                    ParameterName = "@salt",
                    Value = user.Salt
                };

                Connection.OpenConnection();

                var cmd = new SqlCommand(sql, Connection.GetConnection());

                cmd.Parameters.Add(firstNameParam);
                cmd.Parameters.Add(lastNameParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(phoneParam);
                cmd.Parameters.Add(addressParam);
                cmd.Parameters.Add(zipParam);
                cmd.Parameters.Add(cityParam);
                cmd.Parameters.Add(passwordParam);
                cmd.Parameters.Add(saltParam);

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
                var idParam = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                };

                Connection.OpenConnection();

                var query = "select * from Customers where CustomerId = @id";
                var cmd = new SqlCommand(query, Connection.GetConnection());

                cmd.Parameters.Add(idParam);

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
                var emailParam = new SqlParameter()
                {
                    ParameterName = "@email",
                    Value = email
                };

                Connection.OpenConnection();

                var query = "select * from Customers where Email = @email";
                var cmd = new SqlCommand(query, Connection.GetConnection());

                cmd.Parameters.Add(emailParam);

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
                var emailParam = new SqlParameter()
                {
                    ParameterName = "@email",
                    Value = email
                };
                var passwordParam = new SqlParameter()
                {
                    ParameterName = "@password",
                    Value = password
                };

                Connection.OpenConnection();

                var query = "select * from Customers where Email = @email and Password = @password";
                var cmd = new SqlCommand(query, Connection.GetConnection());

                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(passwordParam);

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
            var salt = "";
            try
            {
                var emailParam = new SqlParameter()
                {
                    ParameterName = "@email",
                    Value = email
                };

                Connection.OpenConnection();

                var query = "select salt from Customers where Email = @email";
                var cmd = new SqlCommand(query, Connection.GetConnection());

                cmd.Parameters.Add(emailParam);

                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    salt = reader["salt"].ToString();
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
            return salt;
        }

        public int UpdateUser(User user)
        {
            var result = 0;
            try
            {
                var userIdParam = new SqlParameter()
                {
                    ParameterName = "@userId",
                    Value = user.UserId
                };
                var firstNameParam = new SqlParameter()
                {
                    ParameterName = "@firstName",
                    Value = user.FirstName
                };
                var lastNameParam = new SqlParameter()
                {
                    ParameterName = "@lastName",
                    Value = user.LastName
                };
                var emailParam = new SqlParameter()
                {
                    ParameterName = "@email",
                    Value = user.Email
                };
                var phoneParam = new SqlParameter()
                {
                    ParameterName = "@phone",
                    Value = user.Phone
                };
                var addressParam = new SqlParameter()
                {
                    ParameterName = "@address",
                    Value = user.Address
                };
                var zipParam = new SqlParameter()
                {
                    ParameterName = "@zip",
                    Value = user.Zip
                };
                var cityParam = new SqlParameter()
                {
                    ParameterName = "@city",
                    Value = user.City
                };
                var passwordParam = new SqlParameter()
                {
                    ParameterName = "@password",
                    Value = user.Password
                };
                var saltParam = new SqlParameter()
                {
                    ParameterName = "@salt",
                    Value = user.Salt
                };

                Connection.OpenConnection();

                var sql = "update Customers set " +
                          "FirstName = @firstName, " +
                          "LastName = @lastName, " +
                          "Email = @email, " +
                          "Phone = @phone, " +
                          "Address = @address, " +
                          "Zip = @zip, " +
                          "City = @city, " +
                          "Password = @password, " +
                          "salt =  @salt" +
                          "where CustomerId = @userId";

                var cmd = new SqlCommand(sql, Connection.GetConnection());

                cmd.Parameters.Add(userIdParam);
                cmd.Parameters.Add(firstNameParam);
                cmd.Parameters.Add(lastNameParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(phoneParam);
                cmd.Parameters.Add(addressParam);
                cmd.Parameters.Add(zipParam);
                cmd.Parameters.Add(cityParam);
                cmd.Parameters.Add(passwordParam);
                cmd.Parameters.Add(saltParam);

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
                var idParam = new SqlParameter()
                {
                    ParameterName = "@id",
                    Value = id
                };

                Connection.OpenConnection();

                var sql = "delete from Customers where CustomerId = @id";

                var cmd = new SqlCommand(sql, Connection.GetConnection());
                cmd.Parameters.Add(idParam);

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
