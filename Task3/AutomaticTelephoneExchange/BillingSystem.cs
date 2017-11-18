using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticTelephoneExchange
{
    public class BillingSystem
    {
        private IList<Report> _reports;

        public BillingSystem()
        {
            
        }

        public IList<Report> GetReports(int telephoneNumber, IList<CallInformation> callInformations)
        {
            _reports = new List<Report>();
            var calls = callInformations.Where(x => x.Number == telephoneNumber || x.TargetNumber == telephoneNumber).
                ToList();

            foreach (var call in calls)
            {
                _reports.Add(new Report(call.Number, call.BeginCall, new DateTime((call.EndCall - call.BeginCall).Ticks), call.Cost));
            }

            return _reports;
        }
    }
}
