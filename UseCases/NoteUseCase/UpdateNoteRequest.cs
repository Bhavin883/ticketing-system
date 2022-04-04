namespace UseCases.NoteUseCase
{
    public class UpdateNoteRequest
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PersonId { get; set; }
        public int TicketId { get; set; }
        
    }
}