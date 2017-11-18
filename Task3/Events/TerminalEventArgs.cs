using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;

namespace Task3.Events
{
    public class TerminalEventArgs
    {
        public int TargetNumber { get; private set; }

        public PortState State { get; private set; }

        public string Message { get; private set; }

        public TerminalEventArgs(int targetNumber, PortState state, string message)
        {
            TargetNumber = targetNumber;
            State = state;
            Message = message;
        }

        public TerminalEventArgs(int targetNumber, string message)
        {
            TargetNumber = targetNumber;
            Message = message;
        }
    }
}
