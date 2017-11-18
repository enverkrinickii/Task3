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
        private IDictionary<Contract, Terminal> _contractsAndTerminals;

        public ATE()
        {
            _contractsAndTerminals = new Dictionary<Contract, Terminal>();
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
            return terminal;
        }

        public IDictionary<Contract, Terminal> AddContractsDictionary(Terminal terminal, Contract contract)
        {
            _contractsAndTerminals.Add(contract, terminal);
            return _contractsAndTerminals;
        }

         
    }
}
