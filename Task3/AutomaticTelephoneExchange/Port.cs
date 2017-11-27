using System;
using Task3.Enums;
using Task3.TerminalEvents;

namespace Task3.AutomaticTelephoneExchange
{
    public class Port
    {
        public PortState State;

        public bool IsOnline;

        public event EventHandler<TerminalEventArgs> Answered;

        public event EventHandler<TerminalEventArgs> Called;

        public event EventHandler<TerminalEventArgs> Ended;

        public Port()
        {
            State = PortState.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == PortState.Disconnect)
            {
                State = PortState.Connect;
                terminal.Called += Call;
                terminal.Answered += AnswerToCall;
                terminal.Ended += EndCall;
                IsOnline = true;
            }

            return IsOnline;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == PortState.Connect)
            {
                State = PortState.Disconnect;
                terminal.Called -= Call;
                terminal.Answered -= AnswerToCall;
                terminal.Ended -= EndCall;
                IsOnline = false;
            }
            return IsOnline;
        }

        protected virtual void OnAnswered(TerminalEventArgs e)
        {
            Answered?.Invoke(this, e);
        }

        protected virtual void OnCalled(TerminalEventArgs e)
        {
            Called?.Invoke(this, e);
        }

        protected virtual void OnEnded(TerminalEventArgs e)
        {
            Ended?.Invoke(this, e);
        }

        private void AnswerToCall(object sender, TerminalEventArgs eventArgs)
        {
            State = PortState.Busy;
            OnAnswered(eventArgs);
        }

        private void Call(object sender, TerminalEventArgs eventArgs)
        {
            State = PortState.Busy;
            OnCalled(eventArgs);
        }

        private void EndCall(object sender, TerminalEventArgs eventArgs)
        {
            OnEnded(eventArgs);
            State = PortState.Connect;
        }
    }
}
