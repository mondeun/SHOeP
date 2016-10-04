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
            SqlTransaction level = null;

            try
            {
                Connection.OpenConnection();

                level = Connection.GetConnection().BeginTransaction();
                AddNewOrder(order);

                foreach (KeyValuePair<int, int> item in cartSession)
                {
                    int stockQuantity = new ShoeController().GetShoeQuantity(item.Key);
                    if (stockQuantity < item.Value)
                    {
                        level.Rollback();
                        return false;
                    }
                    ReduceQuantityFromStock(item.Key, item.Value);
                    OrderLine o = new OrderLine();
                    o.Amount = new ShoeController().GetShoePrice(item.Key);
                    o.Discount = 0; //TODO
                    o.OrderId = order.OrderId;
                    o.Quantity = item.Value;
                    o.ShoeId = item.Key;

                    AddProductToOrder(o);
                }

                level.Commit();

            }
            catch {
                if (level != null)
                    level.Rollback();
                return false;
            }
            finally { }

            return true;
        }

        public int ReduceQuantityFromStock(int shoeId, int n)
        {
            var sql = $"UPDATE Stock SET Quantity = Quantity - " + n + " WHERE ShoeId = " + shoeId;
            return InsertToDatabase(sql);
        }

        public int AddNewOrder(Order order)
        {
            var sql = $"INSERT INTO Order (OrderId, OrderNumber, CustomerId, ShippingId, OrderDate, DeliveryDate, TotalPrice, Status)" +
                      $"VALUES ('{order.OrderId}', '{order.OrderNumber}', '{order.CustomerId}', '{order.ShippingId}', '{order.OrderDate}', '{order.DeliveryDate}', '{order.TotalPrice}', '{order.Status}')";

            return InsertToDatabase(sql);
        }

        public int AddProductToOrder(OrderLine line)
        {
            var sql = $"INSERT INTO OrderLines (OrderId, ShoeId, Quantity, Amount, Discount)" +
                      $"VALUES ('{line.OrderId}', '{line.ShoeId}', '{line.Quantity}', '{line.Amount}', '{line.Discount}')";

            return InsertToDatabase(sql);
        }

        public decimal CalculateAmount(decimal price, int quantity) => price * quantity;


        public decimal CalculateTotalPrice(List<decimal> productPrices)
        {
            return productPrices.Sum();
        }
    }
}
