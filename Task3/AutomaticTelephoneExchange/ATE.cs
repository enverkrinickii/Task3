using System;
using System.Collections.Generic;
using System.Threading;
using Task3.Enums;
using Task3.Interfaces;

namespace Task3.AutomaticTelephoneExchange
{
    class ATE: IAte
    {
        private readonly IDictionary<Terminal, Contract> _contractsAndTerminals;

        //событие добавления информации о звонке при новом звонке
        public event EventHandler<CallInformation> NewCall;

        protected virtual void OnNewCall(CallInformation e)
        {
            NewCall?.Invoke(this, e);
        }

        public ATE()
        {
            _contractsAndTerminals = new Dictionary<Terminal, Contract>();
        }

        //Присваиваем пользователю тариф (Заключаем контракт)
        public Contract RegisterNewContract(Client client, Tariff tariff)
        {
            var contract = new Contract(tariff, client);
            return contract;
        }

        //Создаем терминал на основе контракта
        public Terminal CreateTerminal(Contract contract)
        {
            var port = new Port();
            var terminal = new Terminal(contract.Number, port);
            _contractsAndTerminals.Add(terminal, contract);
            return terminal;
        }

        // получаем словать ключ терминал значение его контракт
        public IDictionary<Terminal, Contract> GetContractsDictionary(Terminal terminal, Contract contract)
        {
            return _contractsAndTerminals;
        }


        private int GetCallCost(DateTime beginCall, DateTime endCall, Terminal terminal)
        {
            var contract = _contractsAndTerminals[terminal];
            var callCost = (int)(contract.Tariff.CoastPerMinute * TimeSpan.FromTicks((endCall - beginCall).Ticks).TotalMinutes);
            return callCost;
        }

        //снятие денег со счета
        public void DebitFromAccount(int callCost, Contract contract)
        {
            contract.Client.Pay(callCost);
        }

        //процесс звонка 
        public string CallProcess(Terminal answerer, Terminal ask, int delay, char key)
        {
            string temp;
            ask.Call(answerer.Number);
            if (answerer.Port.State != PortState.Busy && key == 'Y' || key == 'y')
            {
                var beginTime = DateTime.Now;
                answerer.AnswerToCall(ask.Number);
                Thread.Sleep(delay);
                answerer.EndCall();
                var endTime = DateTime.Now;
                var callCost = GetCallCost(beginTime, endTime, ask);
                OnNewCall( new CallInformation(ask.Number, answerer.Number, beginTime, endTime, callCost));

                temp = "";
            }
            else
            {
                temp = answerer.Port.State == PortState.Busy ? $"Terminal with number: {answerer.Number}, is busy now" : $"Terminal with number: {answerer.Number}, have rejected call";
            }
            return temp;
        }
    }
}

