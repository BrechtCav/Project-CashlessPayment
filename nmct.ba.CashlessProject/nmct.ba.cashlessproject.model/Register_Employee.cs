using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Register_Employee
    {
        private Register registerid;
        private Employee employeeid;
        private DateTime from;
        private DateTime until;

        public Register RegisterID
        {
            get { return registerid;}
            set { registerid = value; }
        }
        public Employee EmployeeID
        {
            get { return employeeid; }
            set { employeeid = value; }
        }
        public DateTime From
        {
            get { return from; }
            set { from = value; }
        }
        public DateTime Until
        {
            get { return until; }
            set { until = value; }
        }
        public override string ToString()
        {
            return EmployeeID.EmployeeName + " op toestel " + RegisterID.RegisterName + " van " + From + " tot " + Until;
        }
    }
}
