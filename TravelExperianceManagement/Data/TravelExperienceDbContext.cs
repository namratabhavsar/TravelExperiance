using Microsoft.EntityFrameworkCore;
using TravelExperianceManagement.Models.Domain;

namespace TravelExperianceManagement.Data
{
    public class TravelExperienceDbContext : DbContext
    {
        public TravelExperienceDbContext(DbContextOptions<TravelExperienceDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<Destination> Destinations { get; set; }

    }
}
