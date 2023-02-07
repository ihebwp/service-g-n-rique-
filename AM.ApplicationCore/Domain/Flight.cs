using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {


       
        public int FlightId { get; set; }
        public string AirlineColumn{ get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        public ICollection<Passenger> Passengers
        { get; set; }
        public int PlaneFK { get; set; }

        

        [ForeignKey("PlaneFK")]  // permet  de renomer  la clé  etrangere 
        public plane Plane { get; set; }

    }
}
