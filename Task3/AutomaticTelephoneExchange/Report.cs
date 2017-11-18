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

        public DateTime Duration { get; private set; }

        public int Cost { get; private set; }

        public Report(int number, DateTime date, DateTime duration, int cost)
        {
            Number = number;
            Date = date;
            Duration = duration;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"Telephone number {this.Number}, call Date {this.Date}, duration: {this.Duration}, Coast: {this.Cost}";
        }
    }
}
