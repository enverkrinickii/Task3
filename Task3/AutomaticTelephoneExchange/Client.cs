using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticTelephoneExchange
{
    class Client
    {
        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public double AccountState { get; private set; }

        public Client(string firstName, string secondName, double accountState)
        {
            FirstName = firstName;
            SecondName = secondName;
            AccountState = accountState;
        }
    }
}
