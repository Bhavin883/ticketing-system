using UseCases.Services;
using UseCases.ViewModels;

namespace UseCases.TicketUseCase
{
    public class DeleteTicketUseCase : IDeleteTicketUseCase

    {
        private readonly ITicketService _TicketService;

        public DeleteTicketUseCase(
            ITicketService TicketService)
        {
            _TicketService = TicketService;
        }
        public IResult<ResponseModel> Handle(int request)
        {
            var DeleteTicketResponse = _TicketService.DeleteTicket(request);
            return Result<ResponseModel>.Success(DeleteTicketResponse);
        }
    }
}

