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
        //public delegate void TerminalStateHandler(object sender, TerminalEventArgs e );

        public event EventHandler<TerminalEventArgs> Answered;

        public event EventHandler<TerminalEventArgs> Called;

        public event EventHandler<TerminalEventArgs> Ended;

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

        protected virtual void OnCalled(int targetNumber)
        {
            Called?.Invoke(this, new TerminalEventArgs(targetNumber, $"Идет процесс звонка... Абонент {Number} звонит {targetNumber}"));
        }

        protected virtual void OnEnded()
        {
            Ended?.Invoke(this, new TerminalEventArgs( $"Звонок окончен. Абонент {Number} положил трубку"));
        }

        public void AnswerToCall(int target)
        {
            if (Port.Connect(this) && Port.State != PortState.Busy)
            {
                OnAnswered(target);
            }
        }

        public void Call(int targetNumber)
        {
            OnCalled(targetNumber);
        }

        public void EndCall()
        {
            OnEnded();
        }

    }
}
