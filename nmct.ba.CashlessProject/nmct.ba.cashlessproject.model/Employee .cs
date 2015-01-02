using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Employee
    {
        private int id;
        private string employeename;
        private string address;
        private string email;
        private string phone;
        private string login;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string EmployeeName
        {
            get { return employeename; }
            set { employeename = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value;}
        }
        public string Phone
        {
            get { return phone;}
            set { phone = value; }
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public override string ToString()
        {
            return EmployeeName;
        }
    }
}
