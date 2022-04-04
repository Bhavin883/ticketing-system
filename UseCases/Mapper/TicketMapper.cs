using Common.Entities;
using UseCases.TicketUseCase;

namespace UseCases.Mapper
{
    public class TicketMapper
    {
        public static Ticket Map(CreateTicketRequest request)
        {
            return new Common.Entities.Ticket
            {
                Content = request.Content,  
                PersonId = request.PersonId,
                Notes = request.Notes
            };
        }
        public static Ticket Map(UpdateTicketRequest request)
        {
            return new Common.Entities.Ticket
            {
                Id = request.Id,
                Content = request.Content,
                PersonId = request.PersonId
            };
        }
    }
}
