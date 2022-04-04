using UseCases.Mapper;
using UseCases.Services;
using UseCases.ViewModels;

namespace UseCases.TicketUseCase
{
    public class CreateTicketUseCase : ICreateTicketUseCase

    {
        private readonly ITicketService _TicketService;

        public CreateTicketUseCase(
            ITicketService TicketService)
        {
            _TicketService = TicketService;
        }
        public ResponseModel Handle(CreateTicketRequest request)
        {
            var ticket = TicketMapper.Map(request);
            var CreateTicketResponse = _TicketService.CreateTicket(ticket);
            return CreateTicketResponse;
        }
    }
}

