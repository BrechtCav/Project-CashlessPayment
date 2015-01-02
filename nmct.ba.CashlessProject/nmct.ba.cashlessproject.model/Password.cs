using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Password
    {
        private string login;
        private string oldpassword;
        private string newpassword;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string OldPassword
        {
            get { return oldpassword; }
            set { oldpassword = value; }
        }
        public string NewPassword
        {
            get { return newpassword; }
            set { newpassword = value; }
        }
    }
}
