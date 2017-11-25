using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;

namespace Task3.AutomaticTelephoneExchange
{
    class Contract
    {
        readonly Random _random = new Random();

        public Tariff Tariff { get; private set; }

        public Client Client { get; private set; }

        public int Number { get; private set; }

        public DateTime RegisterDate { get; private set; }

        public Contract(Tariff tariff, Client client)
        {
            Tariff = tariff;
            Client = client;
            Number = _random.Next(1000000, 9999999);
            RegisterDate = DateTime.Today;
        }

        private int GetNumber()
        {
            var number = _random.Next(1000000, 9999999);
            return number;
        }

        public bool ChangeTariff(TariffType type)
        {
            if (DateTime.Now.AddMonths(-1) >= RegisterDate)
            {
                RegisterDate = DateTime.Now;
                Tariff = new Tariff(type);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
