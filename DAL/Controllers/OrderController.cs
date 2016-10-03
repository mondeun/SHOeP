using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Controllers
{
    class OrderController : Controller
    {
        public void AddNewOrder()
        {
        }

        private void AddToOrders()
        {
            /*
             INSERT INTO dbo.Orders(OrderNumber, OrderDate, DeliveryDate, TotalPRice, Status, CustomerId, ShippingId)
             VALUES ('','','','','')
             */

            /*
             INSERT INTO dbo.OrderLines(Quantity, Amount, Discount)
             VALUES ('','','','','')
             */

            //TODO när order genomförs, tas bort fr Stock
           
        }

        public int AddProductToOrder(OrderLine line)
        {
            var result = 0;
            try
            {
                Connection.OpenConnection();

                var sql = $"INSERT INTO OrderLines (OrderId, ShoeId, Quantity, Amount, Discount)" +
                          $"VALUES ('{line.OrderId}', '{line.ShoeId}', '{line.Quantity}', '{line.Amount}', '{line.Discount}')";

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

        public decimal CalculateAmount(decimal price, int quantity) => price * quantity;


        public decimal CalculateTotalPrice(List<decimal> productPrices)
        {
            return productPrices.Sum();
        }
    }
}
