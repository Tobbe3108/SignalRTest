using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTest
{
    public class Resource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<AvailableTime> TimeSlots { get; set; }
    }
}