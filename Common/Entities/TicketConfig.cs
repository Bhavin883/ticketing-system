using Microsoft.EntityFrameworkCore;

namespace Common.Entities
{
    public static class TicketConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });

            modelBuilder.Entity<Ticket>()
             .HasMany(c => c.Notes);


        }
    }
}
