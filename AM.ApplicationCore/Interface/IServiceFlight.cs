using AM.ApplicationCore.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interface
{
    public interface IServiceFlight
    {
        IList<DateTime> GetFlightDates(string destination);

        IList<Flight>GetFlights(string filterType, string filterValue);

        void ShowFlightDetails(plane plane);

        int ProgrammedFlightNumberWithLink(DateTime startDate);


        double DurationAverage(string destination);

        int ProgrammedFlightNumberLambda(DateTime startDate);

        IEnumerable<Flight> orderDurationFlight();

        IEnumerable<Traveller> SeniorTraveller(Flight flight);


        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();
    }
}
