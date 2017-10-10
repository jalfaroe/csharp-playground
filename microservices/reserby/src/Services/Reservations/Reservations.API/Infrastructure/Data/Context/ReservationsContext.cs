using Microsoft.EntityFrameworkCore;
using reserby.Reservations.API.Infrastructure.Data.Models;

namespace reserby.Reservations.API.Infrastructure.Data.Context
{
    public class ReservationsContext : DbContext
    {
        public ReservationsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
    }
}