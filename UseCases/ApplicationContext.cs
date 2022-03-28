using Common.Entities;
using Microsoft.EntityFrameworkCore;
namespace UseCases
{
    public class ApplicationContext : AuditableIdentityContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           
        }
       
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Note> Notes { get; set; }

        public string DatabasePath { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PersonConfig.Configure(modelBuilder);
            TicketConfig.Configure(modelBuilder);
            NoteConfig.Configure(modelBuilder);
        }
    }
}
