﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Controllers
{
    public class User : Controller
    {
        public int AddUser(Users user)
        {
            var result = 0;
            try
            {
                _connection.OpenConnection();

                var sql = $"insert into customers (FirstName, LastName, Email, Phone, Address, Zip, City, Password) " +
                          $"values ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Phone}', '{user.Address}', '{user.Zip}', '{user.City}', '{user.Password}')";

                var cmd = new SqlCommand(sql, _connection.GetConnection());
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                _connection.CloseConnection();
            }
            return result;
        }
    }
}
