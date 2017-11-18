using System;
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

            CallProcess(terminal, terminal1, ate);
            CallProcess(terminal1, terminal2, ate);
            CallProcess(terminal2, terminal, ate);

            Console.ReadKey();
        }

        private static void Display(object sender, TerminalEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void CallProcess(Terminal terminal, Terminal terminal2, ATE ate)
        {
            
            var flag = true;
            terminal2.Call(terminal.Number);
            while (flag)
            {
                Console.WriteLine("Do you want to answer? Y/N");
                char k = Console.ReadKey().KeyChar;
                if (k == 'Y' || k == 'y')
                {
                    flag = false;
                    terminal.AnswerToCall(terminal2.Number);
                    DateTime beginTime = DateTime.Now;
                    Thread.Sleep(1000);
                    terminal.EndCall();
                    DateTime endTime = DateTime.Now;
                    var callCost = ate.GetCallCost(beginTime, endTime, terminal2);
                    CallInformation callInformation = new CallInformation(terminal2.Number, terminal.Number, beginTime, endTime, callCost);
                }
                else
                {
                    Console.WriteLine($"Terminal with number: {terminal.Number}, have rejected call");
                }

                Console.WriteLine();
            }

        }
    }
}
