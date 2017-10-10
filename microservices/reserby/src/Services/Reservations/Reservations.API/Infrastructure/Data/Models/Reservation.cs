using System;

namespace reserby.Reservations.API.Infrastructure.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int EntityId { get; set; }

        public int UserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Contact { get; set; }
    }
}