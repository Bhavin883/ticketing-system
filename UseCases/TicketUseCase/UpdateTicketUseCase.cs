using UseCases.Mapper;
using UseCases.Services;
using UseCases.ViewModels;

namespace UseCases.TicketUseCase
{
    public class UpdateTicketUseCase : IUpdateTicketUseCase

    {
        private readonly ITicketService _TicketService;

        public UpdateTicketUseCase(
            ITicketService TicketService)
        {
            _TicketService = TicketService;
        }
        public IResult<ResponseModel> Handle(UpdateTicketRequest request)
        {
            var ticket = TicketMapper.Map(request);
            var UpdateTicketResponse = _TicketService.UpdateTicket(ticket);
            return Result<ResponseModel>.Success(UpdateTicketResponse);
            
        }
    }
}

