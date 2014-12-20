using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Product
    {
        private int id;
        private string productname;
        private double price;
        private int categorie;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }
        public override string ToString()
        {
            return ProductName;
        }


    }
}
