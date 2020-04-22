using System;

namespace SignalRTest
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public ReserveTime Timeslot { get; set; }
        public Guid UserId { get; set; }
        public Guid ResourceId { get; set; }
    }
}