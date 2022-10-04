using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public DbSet<Destination> Destination {get; set;}

        public TravelApiContext(DbContextOptions<TravelApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>()
            .HasData(
                new Destination {DestinationId = 1 , Username = "Danny" , Country = "Nigeria" , City = "Lagos" , DestinationName = "EmmanuelPark" , Review = "Emmanurl park is one of the best restaurants in nigeria"}
            );
        }
    }
}