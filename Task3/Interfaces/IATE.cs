using System.Collections.Generic;
using Task3.AutomaticTelephoneExchange;

namespace Task3.Interfaces
{
    public interface IAte
    {
        Contract RegisterNewContract(Client client, Tariff tariff);
        Terminal CreateTerminal(Contract contract);
        IDictionary<Terminal, Contract> GetContractsDictionary(Terminal terminal, Contract contract);
        void DebitFromAccount(int callCost, Contract contract);
        string CallProcess(Terminal answerer, Terminal ask, int delay, char key);
    }
}
