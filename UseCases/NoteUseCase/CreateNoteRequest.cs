
using Common.Entities;
using System.Collections.Generic;

namespace UseCases.NoteUseCase
{
    public class CreateNoteRequest
    {
        public string Content { get; set; }
        public int PersonId { get; set; }
        public int TicketId { get; set; }
    }
}