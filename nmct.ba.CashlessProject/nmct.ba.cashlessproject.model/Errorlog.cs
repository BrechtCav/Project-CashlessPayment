using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.model
{
    public class Errorlog
    {
        private Register registerid;
        private DateTime timestamp;
        private string message;
        private string stacktrace;

        public Register RegisterID
        {
            get { return registerid; }
            set { registerid = value; }
        }
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public string Stacktrace
        {
            get { return stacktrace; }
            set { stacktrace = value; }
        }
    }
}
