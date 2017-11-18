using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;

namespace Task3.AutomaticTelephoneExchange
{
    class Tariff
    {
        public int CoastPerMinute { get; private set; }

        public int FreeMinutes { get; private set; }

        public TariffType Type { get; private set; }

        public Tariff(int coastPerMinute, int freeMinutes, TariffType type)
        {
            CoastPerMinute = coastPerMinute;
            FreeMinutes = freeMinutes;
            Type = type;
        }
    }
}
