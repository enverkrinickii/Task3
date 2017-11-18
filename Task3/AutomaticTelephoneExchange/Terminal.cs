using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;
using Task3.Events;

namespace Task3.AutomaticTelephoneExchange
{
    public class Terminal
    {
        public delegate void TerminalStateHandler(object sender, TerminalEventArgs e );

        public event TerminalStateHandler Answered;

        public event TerminalStateHandler InCalled;

        public event TerminalStateHandler Ended;

        public int Number { get; private set; }

        public Port Port { get; private set; }

        public Terminal(int number, Port port)
        {
            Number = number;
            Port = port;
        }

        

        protected virtual void OnAnswered(int targetNumber)
        {
            Answered?.Invoke(this, new TerminalEventArgs(targetNumber, PortState.Busy, $"Принят исходящий вызов от {targetNumber}"));
        }

        protected virtual void OnInCalled(int targetNumber)
        {
            InCalled?.Invoke(this, new TerminalEventArgs(targetNumber, $"Идет процесс звонка... Абонент {Number} звонит {targetNumber}"));
        }

        protected virtual void OnEnded(int targetNumber)
        {
            Ended?.Invoke(this, new TerminalEventArgs(targetNumber, $"Звонок окончен. Абонент {Number} положил трубку"));
        }

        public void AnswerToCall(int target)
        {
            if (Port.Connect())
            {
                OnAnswered(target);
            }
        }

        public void Call(int targetNumber)
        {
            OnInCalled(targetNumber);
        }

        public void EndCall(int target)
        {
            OnEnded(target);
        }

    }
}
