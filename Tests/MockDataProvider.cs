using Common.Entities;
using UseCases;
namespace Tests
{
    internal class MockDataProvider
    {
        public static void GeneratePersonAndTicketTestData(ApplicationContext context)
        {
            var person = new Person() { Forename = "Joe", Surname = "Morgan", IsAdmin = true };
            var ticket = new Ticket() { PersonId = 1, Content = "Add line chart with growth and time fields." };
            context.Persons.Add(person);
            context.Tickets.Add(ticket);
            context.SaveChanges();
        }
        public static void GenerateNoteTestData(ApplicationContext context)
        {
            var noteLists = new Note[] {
                new() { PersonId = 1, TicketId = 1, Content = "Configure data source." },
                new() { PersonId = 1, TicketId = 1, Content = "Bind chart." }
            };
            context.Notes.AddRange(noteLists);
            context.SaveChanges();
        }
    }
}