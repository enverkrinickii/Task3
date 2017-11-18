using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;

namespace Task3.AutomaticTelephoneExchange
{
    public class Port
    {
        public PortState State;
        public bool IsOnline;
        
        public Port()
        {
            State = PortState.Disconnect;
        }

        public bool Connect()
        {
            if (State == PortState.Disconnect)
            {
                State = PortState.Connect;
                IsOnline = true;
            }

            return IsOnline;
        }

        public bool Disconnect()
        {
            if (State == PortState.Connect)
            {
                State = PortState.Disconnect;
                IsOnline = false;
            }
            return IsOnline;
        }
        
    }
}
