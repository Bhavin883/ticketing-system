using System.Collections.Generic;
using Common.Entities;

namespace UseCases.TicketUseCase
{
    public interface IDisplayAllTicketUseCase : IUseCaseHandler<int, List<Ticket>>
    {
    }
}
