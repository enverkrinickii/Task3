using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;

namespace Task3.AutomaticTelephoneExchange
{
    public class Tariff
    {
        public TariffType Type { get; private set; }

        public int CoastPerMinute { get; private set; }

        public int CoastPerMonth { get; private set; }

        public Tariff(TariffType type)
        {
            Type = type;
            CreateTariff(type);
        }

        private void CreateTariff(TariffType type)
        {
            switch (type)
            {
                case TariffType.Low:
                {
                    CoastPerMinute = 5;
                    CoastPerMonth = 100;
                    break;
                }
                case TariffType.Medium:
                {
                    CoastPerMinute = 8;
                    CoastPerMonth = 200;
                    break;
                }
                case TariffType.Premium:
                {
                    CoastPerMinute = 10;
                    CoastPerMonth = 500;
                    break;
                }
                default:
                {
                    CoastPerMinute = 0;
                    CoastPerMonth = 0;
                    break;
                }
            }
        }
    }
}
