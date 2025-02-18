using Microsoft.EntityFrameworkCore;

namespace TripAPI.Models
{
    public class TripContext : DbContext
    {
        // Constructor that configures the database context options
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        {

        }
        public DbSet<Trip> Trips { get; set; }
    }
}
