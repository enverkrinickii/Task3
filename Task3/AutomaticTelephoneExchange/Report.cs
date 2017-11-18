using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticTelephoneExchange
{
    public class Report
    {
        public int Number { get; private set; }

        public DateTime Date { get; private set; }

        public DateTime Time { get; private set; }

        public int Cost { get; private set; }

        public Report(int number, DateTime date, DateTime time, int cost)
        {
            Number = number;
            Date = date;
            Time = time;
            Cost = cost;
        }
    }
}
