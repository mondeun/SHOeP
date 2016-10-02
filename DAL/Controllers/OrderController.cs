using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
