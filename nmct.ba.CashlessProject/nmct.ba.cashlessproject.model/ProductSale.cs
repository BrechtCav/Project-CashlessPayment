using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class ProductSale
    {
        private Product productid;
        private int amountpr;
        private double totalprice;

        public Product ProductID
        {
            get { return productid; }
            set { productid = value; }
        }
        public int AmountPR
        {
            get { return amountpr; }
            set { amountpr = value; }
        }
        public double Totalprice
        {
            get { return totalprice; }
            set { totalprice = value; }
        }
        public override string ToString()
        {
            return ProductID.ProductName + " " + AmountPR;
        }
    }
}
