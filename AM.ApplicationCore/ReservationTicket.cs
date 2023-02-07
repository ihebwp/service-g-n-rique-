using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore
{
    public class ReservationTicket
    {
        public DateTime DateReservation { get; set; }
        public float Prix { get; set; }

        public int TicketFK { get; set; }

        public string PassengerFK { get; set; }



        [ForeignKey("PassengerFK")]
        public Passenger Passenger { get; set; }
        [ForeignKey("TicketFK")]

        public Ticket Ticket { get; set; }

                

    }
}
