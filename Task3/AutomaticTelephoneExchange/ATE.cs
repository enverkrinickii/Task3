using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticTelephoneExchange
{
    class ATE
    {
        private IDictionary<Terminal, Contract> _contractsAndTerminals;

        private IList<CallInformation> _callInformations = new List<CallInformation>();

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

        public IDictionary<Terminal, Contract> GetContractsDictionary(Terminal terminal, Contract contract)
        {
            return _contractsAndTerminals;
        }

        public int GetCallCost(DateTime beginCall, DateTime endCall, Terminal terminal)
        {
            var contract = _contractsAndTerminals[terminal];
            var callCost = (int)(contract.Tariff.CoastPerMinute * TimeSpan.FromTicks((endCall - beginCall).Ticks).TotalMinutes);
            return callCost;
        }

        public void DebitFromAccount(int callCost, Contract contract)
        {
            contract.Client.Pay(callCost);
        }

        public void AddCallInformation(CallInformation callInformation)
        {
            _callInformations.Add(callInformation);
        }

        public IList<CallInformation> GetCallInformations()
        {
            return _callInformations;
        }

    }
}
