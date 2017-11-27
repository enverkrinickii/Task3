using System;
using System.Collections.Generic;
using System.Linq;
using Task3.Interfaces;

namespace Task3.AutomaticTelephoneExchange
{
    public class BillingSystem : IBs
    {
        private readonly IList<Report> _reports;

        private readonly IList<CallInformation> _callInformations;

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
            var calls = _callInformations.Where(x => x.Number == telephoneNumber /*|| x.TargetNumber == telephoneNumber*/).
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


        public double GetCoastForMonth(int number)
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            var reportsOfNumber =
                _reports.Where(x => x.Number == number).Where(x => x.Date <= last && x.Date >= first );
            return reportsOfNumber.Sum(report => report.Cost);
        }


    }
}
