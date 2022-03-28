using Common.Entities;
using UseCases.TicketUseCase;

namespace AareonTechnicalTest.Mapper
{
    public class TicketMapper
    {
        public static UpdateTicketRequest GetUpdateTicket(Ticket Ticket)
        {
            var TicketUpdate =  new UpdateTicketRequest();
            TicketUpdate.Id = Ticket.Id;
            TicketUpdate.PersonId = Ticket.PersonId;
            TicketUpdate.Content = Ticket.Content;

            return TicketUpdate;
        }
    }
}
