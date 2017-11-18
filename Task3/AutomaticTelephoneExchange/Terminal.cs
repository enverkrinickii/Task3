using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticTelephoneExchange
{
    class Terminal
    {
        public int Number { get; private set; }
        public Port Port { get; private set; }

        public Terminal(int number, Port port)
        {
            Number = number;
            Port = port;
        }

        
    }
}
