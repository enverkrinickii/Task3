using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticTelephoneExchange
{
    class Client
    {
        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public int AccountState { get; private set; }

        public Client(string firstName, string secondName, int accountState)
        {
            FirstName = firstName;
            SecondName = secondName;
            AccountState = accountState;
        }

        public void AddMoney(int sum)
        {
            AccountState += sum;
        }

        public void Pay(int sum)
        {
            AccountState -= sum;
        }
    }
}
