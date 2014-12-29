using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Transfer
    {
        public Customer Cust { get; set; }
        public double Amount { get; set; }
        public int Teken { get; set; }
    }
}
