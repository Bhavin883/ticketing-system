using Microsoft.EntityFrameworkCore;

namespace Common.Entities
{
    public static class NoteConfig
    {
        public static void Configure(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Note>().HasKey(e => e.Id);
           
        }
    }
}
