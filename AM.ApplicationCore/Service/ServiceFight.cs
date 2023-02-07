using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class ServiceFight : IServiceFlight
    {
        public IList<Flight> Flights { get; set; } = new List<Flight>();
        public IList<Traveller> Travellers { get; set; } = new List<Traveller>();



        public IList<DateTime> GetFlightDates(string destination)

        {
            IList<DateTime> Results = new List<DateTime>();

            /*for (int i = 0; i <= Flights.Count(); i++)
            {
                if (Flights[i].Destination.Equals(destination)){
                    Results.Add(Flights[i].FlightDate);
                }


            }*/

            // foreach (Flight f in Flights) {
            //   if (f.Destination.Equals(destination))
            //  {
            //      Results.Add(f.FlightDate);
            //  }
            // return Results; 
            var querry = from f in Flights
                         where f.Destination == destination
                         select f.FlightDate;
            return querry.ToList();

        }



        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            throw new NotImplementedException();
        }

        public int ProgrammedFlightNumberWithLink(DateTime startDate)
        {
            var querry = from f in Flights
                         where (f.FlightDate - startDate).TotalDays < 7 && (f.FlightDate > startDate)
                         select f;
            return querry.Count();
        }

        public int ProgrammedFlightNumberLambda(DateTime startDate)
        {
            var lambda = Flights.Where(f => (f.FlightDate - startDate).TotalDays < 7 && f.FlightDate > startDate).Count();
            return lambda;
        }

        public void ShowFlightDetails(plane plane)
        {
            //var querry = from f in Flights
            //where f.Plane.Equals(plane)
            //select new { f.FlightDate, f.Destination };


            //foreach (var f in querry)
            //{
            //  Console.WriteLine(f.FlightDate + f.Destination);

            //}

            var lambda = Flights.Where(f => f.Plane.Equals(plane)).Select(p => new { p.FlightDate, p.Destination });

            foreach (var f in lambda)
            {
                Console.WriteLine(f.FlightDate + f.Destination);


            }



        }

        public double DurationAverage(string destination)
        {  //withe Lambda
           //return Flights.Where(f => f.Destination.Equals(destination)).Select(p => p.EstimatedDuration).Average();

            //with Link
            var querry = from f in Flights
                         where (f.Destination.Equals(destination))
                         select f.EstimatedDuration;
            return querry.Average();    
                         
        }

        public IEnumerable<Flight> orderDurationFlight()
        {
            //return Flights.OrderByDescending(f=> f.EstimatedDuration);
            var querry = from f in Flights
                         orderby f.EstimatedDuration descending
                         select f;
            return querry;
            
        }

        public IEnumerable<Traveller> SeniorTraveller(Flight fly)
        {   // ofType (heritage) et  via  le  diagrame  de classe on  peux  recuperer  la liste des passengers 
            //return fly.Passengers.OfType<Traveller>().OrderBy(p=>p.BirthDate).Take(3);


            var querry = from p in fly.Passengers.OfType<Traveller>()
                         orderby p.BirthDate descending
                         select p;
            return querry;


        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //with Link
            /* var querry = from f in Flights
                          group f by f.Destination;
             foreach (var item in querry)
             {
                 Console.WriteLine(item.Key);
                 foreach (var i in item)
                 {
                     Console.WriteLine(i.FlightDate);
                 }
             }


             return querry;*/

            var Lambda = Flights.GroupBy(f => f.Destination);
            foreach (var item in Lambda)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(i.FlightDate);
                }
            }


            return Lambda;

        }
    }
}