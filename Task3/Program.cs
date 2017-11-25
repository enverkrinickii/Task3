using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task3.AutomaticTelephoneExchange;
using Task3.Enums;
using Task3.TerminalEvents;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var ate =  new ATE();
            var bs = new BillingSystem();

            ate.NewCall += bs.AddNewCallInfo;

            var contract = ate.RegisterNewContract(new Client("Ivan", "Ivanov", 300), new Tariff(TariffType.Low));
            Thread.Sleep(100);
            var contract1 = ate.RegisterNewContract(new Client("Petr", "Petrov", 500), new Tariff(TariffType.Premium));
            Thread.Sleep(100);
            var contract2 = ate.RegisterNewContract(new Client("Alex", "Black", 400), new Tariff(TariffType.Medium));

            var terminal = ate.CreateTerminal(contract);
            var terminal1 = ate.CreateTerminal(contract1);
            var terminal2 = ate.CreateTerminal(contract2);

            terminal.Answered += Display;
            terminal1.Answered += Display;
            terminal2.Answered += Display;

            terminal.Called += Display;
            terminal1.Called += Display;
            terminal2.Called += Display;

            terminal.Ended += Display;
            terminal1.Ended += Display;
            terminal2.Ended += Display;

            var key = AnswerKey();
            Console.WriteLine(ate.CallProcess(terminal1, terminal, 10000, key));
            key = AnswerKey();
            Console.WriteLine(ate.CallProcess(terminal2, terminal1, 2000, key));
            key = AnswerKey();
            Console.WriteLine(ate.CallProcess(terminal, terminal1, 4000, key));


            var reports = bs.GetReports(terminal1.Number);

            foreach (var report in reports)
            {
                Console.WriteLine(report);
            }

            var sorted = bs.SortByDuration();

            foreach (var report in sorted)
            {
                Console.WriteLine(report);
            }

            Console.ReadKey();
        }

        private static void Display(object sender, TerminalEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static char AnswerKey()
        {
            Console.WriteLine("Do you want to answer? Y/N");
            var k = Console.ReadKey().KeyChar;
            return k;
        }


    }
}
