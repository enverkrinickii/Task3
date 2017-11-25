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

        private IList<CallInformation> _callInformations;

        public BillingSystem()
        {
            _reports = new List<Report>();
            _callInformations = new List<CallInformation>();
        }

        public void AddNewCallInfo(object sender, CallInformation callInformation)
        {
            _callInformations.Add(callInformation);
        }

        public IEnumerable<Report> GetReports(int telephoneNumber)
        {
            var calls = _callInformations.Where(x => x.Number == telephoneNumber || x.TargetNumber == telephoneNumber).
                ToList();

            foreach (var call in calls)
            {
                _reports.Add(new Report(call.Number, call.BeginCall, new DateTime((call.EndCall - call.BeginCall).Ticks), call.Cost));
            }

            return _reports;
        }

        public IEnumerable<Report> SortByNumber()
        {
           return _reports.OrderBy(r => r.Number);
        }

        public IEnumerable<Report> SortByDuration()
        {
            return _reports.OrderBy(r => r.Duration);
        }

        public IEnumerable<Report> SortByCost()
        {
            return _reports.OrderBy(r => r.Cost);
        }



    }
}
