using System;

namespace Task3.AutomaticTelephoneExchange
{
    public class CallInformation
    {
        public int Number { get; private set; }

        public int TargetNumber { get; private set; }

        public DateTime BeginCall { get; private set; }

        public DateTime EndCall { get; private set; }

        public int Cost { get; private set; }

        public CallInformation(int number, int targetNumber, DateTime beginCall, DateTime endCall, int cost)
        {
            Number = number;
            TargetNumber = targetNumber;
            BeginCall = beginCall;
            EndCall = endCall;
            Cost = cost;
        }

        public CallInformation(int number, int targetNumber, DateTime beginCall) 
        {
            Number = number;
            TargetNumber = targetNumber;
            BeginCall = beginCall;
        }
    }
}
