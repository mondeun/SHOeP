using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shoe
    {
        public int StockId { get; set; }
        public int ModelId { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
    }
}
