using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class IT_Register
    {
        private int id;
        private string registername;
        private string device;
        private DateTime purchasedate;
        private DateTime expiresdate;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string RegisterName
        {
            get { return registername; }
            set { registername = value; }
        }
        public string Device
        {
            get { return device; }
            set { device = value; }
        }
        public DateTime PurchaseDate
        {
            get { return purchasedate; }
            set { purchasedate = value; }
        }
        public DateTime ExpiresDate
        {
            get { return expiresdate; }
            set { expiresdate = value; }
        }
    }
}
