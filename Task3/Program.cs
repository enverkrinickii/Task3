using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task3.AutomaticTelephoneExchange;
using Task3.Enums;
using Task3.Events;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ATE ate =  new ATE();
            BillingSystem bs = new BillingSystem();

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

            terminal.InCalled += Display;
            terminal1.InCalled += Display;
            terminal2.InCalled += Display;

            terminal.Ended += Display;
            terminal1.Ended += Display;
            terminal2.Ended += Display;

            CallProcess(terminal1, terminal, ate, 10000);
            CallProcess(terminal2, terminal1, ate, 1000);
            CallProcess(terminal, terminal1, ate, 1000);

            var calls = ate.GetCallInformations();

            var reports = bs.GetReports(terminal1.Number, calls);

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

        private static void CallProcess(Terminal answerer, Terminal ask, ATE ate, int delay)
        {
            
            var flag = true;
            ask.Call(answerer.Number);
            while (flag)
            {
                Console.WriteLine("Do you want to answer? Y/N");
                char k = Console.ReadKey().KeyChar;
                if (k == 'Y' || k == 'y')
                {
                    flag = false;
                    answerer.AnswerToCall(ask.Number);
                    DateTime beginTime = DateTime.Now;
                    Thread.Sleep(delay);
                    answerer.EndCall();
                    DateTime endTime = DateTime.Now;
                    var callCost = ate.GetCallCost(beginTime, endTime, ask);
                    CallInformation callInformation = new CallInformation(ask.Number, answerer.Number, beginTime, endTime, callCost);
                    ate.AddCallInformation(callInformation);
                }
                else
                {
                    Console.WriteLine($"Terminal with number: {answerer.Number}, have rejected call");
                }

                Console.WriteLine();
            }

        }
    }
}
