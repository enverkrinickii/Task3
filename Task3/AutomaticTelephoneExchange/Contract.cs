using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticTelephoneExchange
{
    class Contract
    {
        
        public Tariff Tariff { get; private set; }

        public Client Client { get; private set; }

        public int Number { get; private set; }

        public DateTime RegisterDate { get; private set; }

        public Contract(Tariff tariff, Client client)
        {
            Tariff = tariff;
            Client = client;
            Number = GetNumber();
            RegisterDate = DateTime.Today;
        }

        private int GetNumber()
        {
            var random = new Random();

            var number = random.Next(1000000, 9999999);

            return number;
        }

    }
}
