using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.AutomaticTelephoneExchange
{
    public class BillingSystem
    {
        public IList<Report> Reports = new List<Report>();

        public BillingSystem(/*IList<Report> reports*/)
        {
            //_reports = reports;
        }

        public IList<Report> GetReports(int telephoneNumber, IList<CallInformation> callInformations)
        {
            var calls = callInformations.Where(x => x.Number == telephoneNumber || x.TargetNumber == telephoneNumber).
                ToList();

            foreach (var call in calls)
            {
                Reports.Add(new Report(call.Number, call.BeginCall, new DateTime((call.EndCall - call.BeginCall).Ticks), call.Cost));
            }

            return Reports;
        }

        public IEnumerable<Report> SortByNumber()
        {
           return Reports.OrderBy(r => r.Number);
        }

        public IEnumerable<Report> SortByDuration()
        {
            return Reports.OrderBy(r => r.Duration);
        }

        public IEnumerable<Report> SortByCost()
        {
            return Reports.OrderBy(r => r.Cost);
        }

    }
}
