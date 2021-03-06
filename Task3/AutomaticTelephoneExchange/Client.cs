﻿namespace Task3.AutomaticTelephoneExchange
{
    public class Client
    {
        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public int AccountState { get; private set; }

        public Client(string firstName, string secondName, int accountState)
        {
            FirstName = firstName;
            SecondName = secondName;
            AccountState = accountState;
        }

        //добавление на счет
        public void AddMoney(int sum)
        {
            AccountState += sum;
        }

        //снятие со счета
        public void Pay(int sum)
        {
            AccountState -= sum;
        }
    }
}
