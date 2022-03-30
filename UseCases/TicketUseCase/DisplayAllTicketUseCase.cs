
using System.Collections.Generic;
using Common.Entities;
using UseCases.Services;

namespace UseCases.TicketUseCase
{
    public class DisplayAllTicketUseCase : IDisplayAllTicketUseCase

    {
        private readonly ITicketService _TicketService;

        public DisplayAllTicketUseCase(
            ITicketService TicketService)
        {
            _TicketService = TicketService;
        }
        public List<Ticket> Handle(int request)
        {
            var DisplayTicketResponse = _TicketService.GetTicketList();
            return DisplayTicketResponse;
        }
    }
}

