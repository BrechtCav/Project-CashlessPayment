using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Sale
    {
        private int id;
        private DateTime timestamp;
        private Customer customerid;
        private Register registerid;
        private Product productid;
        private int amount;
        private double totalprice;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        public Customer CustomerID
        {
            get { return customerid; }
            set { customerid = value; }
        }
        public Register RegisterID
        {
            get { return registerid; }
            set { registerid = value; }
        }
        public Product ProductID
        {
            get { return productid; }
            set { productid = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public double Totalprice
        {
            get { return totalprice; }
            set { totalprice = value; }
        }
        public override string ToString()
        {
            return "Op " + Timestamp + " kocht " + CustomerID.Name + " bij " + RegisterID.RegisterName + " " + Amount + " " + ProductID.ProductName + " voor een totaal prijs van " + Totalprice;
        }
    }
}
