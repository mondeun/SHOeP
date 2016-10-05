using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Controllers
{
    public class OrderController : Controller
    {

        public bool Transaction(Order order, Dictionary<int, int> cartSession)
        {
            Connection.OpenConnection();

            BeginTransaction();

            AddNewOrder(order);
            int orderId = GetOrderId();

            foreach (KeyValuePair<int, int> item in cartSession)
            {
                int stockQuantity = new ShoeController().GetShoeQuantity(item.Key);
                if (stockQuantity < item.Value)
                {
                    Rollback();
                    return false;
                }
                ReduceQuantityFromStock(item.Key, item.Value);
                OrderLine o = new OrderLine();
                o.Amount = new ShoeController().GetShoePrice(item.Key);
                o.Discount = 0; 
                o.OrderId = orderId;
                o.Quantity = item.Value;
                o.ShoeId = item.Key;

                AddProductToOrder(o);
            }

            Commit();

            Connection.CloseConnection();

            return true;
        }

        public int ReduceQuantityFromStock(int shoeId, int n)
        {
            var sql = $"UPDATE Stock SET Quantity = Quantity - " + n + " WHERE ShoeId = " + shoeId;
            var cmd = new SqlCommand(sql, Connection.GetConnection());
            return cmd.ExecuteNonQuery();
        }

        public int AddNewOrder(Order order)
        {
            var sql = $"INSERT INTO Orders (OrderNumber, CustomerId, ShippingId, OrderDate, DeliveryDate, TotalPrice, Status)" +
                      $"VALUES ('{order.OrderNumber}', '{order.CustomerId}', '{order.ShippingId}', '{order.OrderDate}', '{order.DeliveryDate}', '{order.TotalPrice}', '{order.Status}')";
            var cmd = new SqlCommand(sql, Connection.GetConnection());
            return cmd.ExecuteNonQuery();
        }

        public int GetOrderId()
        {

            var sql = $"SELECT CAST(SCOPE_IDENTITY() as int)";
            SqlCommand myCommand = new SqlCommand(sql, Connection.GetConnection());
            SqlDataReader dataReader = myCommand.ExecuteReader();
            if (dataReader.Read())
            {
                int id = dataReader.GetInt32(0);
                dataReader.Close();
                return id;
            }
            return -1;
        }

        public int AddProductToOrder(OrderLine line)
        {
            var sql = $"INSERT INTO OrderLines (OrderId, ShoeId, Quantity, Amount, Discount)" +
                      $"VALUES ('{line.OrderId}', '{line.ShoeId}', '{line.Quantity}', '{line.Amount}', '{line.Discount}')";
            var cmd = new SqlCommand(sql, Connection.GetConnection());
            return cmd.ExecuteNonQuery();
        }

        public int BeginTransaction()
        {
            var sql = $"BEGIN TRANSACTION;";
            var cmd = new SqlCommand(sql, Connection.GetConnection());
            return cmd.ExecuteNonQuery();
        }

        public int Rollback()
        {
            var sql = $"IF @@TRANCOUNT > 0\nROLLBACK TRANSACTION;";
            var cmd = new SqlCommand(sql, Connection.GetConnection());
            return cmd.ExecuteNonQuery();
        }
        public int Commit()
        {
            var sql = $"IF @@TRANCOUNT > 0\nCOMMIT TRANSACTION;";
            var cmd = new SqlCommand(sql, Connection.GetConnection());
            return cmd.ExecuteNonQuery();
        }

        public decimal CalculateAmount(decimal price, int quantity) => price * quantity;


        public decimal CalculateTotalPrice(List<decimal> productPrices)
        {
            return productPrices.Sum();
        }
    }
}
