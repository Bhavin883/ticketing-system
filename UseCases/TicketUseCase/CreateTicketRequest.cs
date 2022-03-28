
using Common.Entities;
using System.Collections.Generic;

namespace UseCases.TicketUseCase
{
    public class CreateTicketRequest
    {
        public string Content { get; set; }
        public int PersonId { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}