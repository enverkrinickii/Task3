using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;

namespace Task3.AutomaticTelephoneExchange
{
    class Port
    {
        public PortState State;
        private bool _isOnline;
        
        public Port()
        {
            this.State = PortState.Disconnect;
        }

        
    }
}
