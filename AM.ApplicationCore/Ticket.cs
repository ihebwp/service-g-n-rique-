using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore
{
    public class Ticket
    {
        public string Classe { get; set; }

        public String Destination { get; set; }

        public int Id { get; set; }
        public ICollection<ReservationTicket> ReservationTickets { get; set; }

    }
}
