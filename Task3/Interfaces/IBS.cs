using System.Collections.Generic;
using Task3.AutomaticTelephoneExchange;

namespace Task3.Interfaces
{
    public interface IBs
    {
        void AddNewCallInfo(object sender, CallInformation callInformation);
        IEnumerable<Report> GetReports(int telephoneNumber);
        IEnumerable<Report> SortByNumber();
        IEnumerable<Report> SortByDuration();
        IEnumerable<Report> SortByCost();
        double GetCoastForMonth(int number);
    }
}
