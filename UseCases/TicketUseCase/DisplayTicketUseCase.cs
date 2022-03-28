
using Common.Entities;
using UseCases.Services;

namespace UseCases.TicketUseCase
{
    public class DisplayTicketUseCase : IDisplayTicketUseCase

    {
        private readonly ITicketService _TicketService;

        public DisplayTicketUseCase(
            ITicketService TicketService)
        {
            _TicketService = TicketService;
        }
        public IResult<Ticket> Handle(int request)
        {
            var DisplayTicketResponse = _TicketService.GetTicketDetailsById(request);
            return Result<Ticket>.Success(DisplayTicketResponse);
        }
    }
}

