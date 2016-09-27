using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shipping
    {
        public int ShiipingId { get; set; }
        public string CompanyName { get; set; }
        public decimal Charge { get; set; }
    }
}
