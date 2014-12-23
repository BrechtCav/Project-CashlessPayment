using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Customer
    {
        private int id;
        private string name;
        private string address;
        private byte[] picture;
        private double balance;
        private string nationalnumber;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public string NationalNumber
        {
            get { return nationalnumber; }
            set { nationalnumber = value; }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
