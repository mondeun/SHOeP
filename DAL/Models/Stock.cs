using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Stock
    {
        public int Quantity { get; set; }
        public DateTime QuantityChangedDate { get; set; }
    }
}
