using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Register
    {
        private int registerid;
        private string registername;
        private string device;

        public int RegisterID
        {
            get
            {
                return registerid;
            }
            set
            {
                registerid = value;
            }
        }
        public string RegisterName
        {
            get
            {
                return registername;
            }
            set
            {
                registername = value;
            }
        }
        public string Device
        {
            get { return device; }
            set { device = value; }
        }
    }
}
