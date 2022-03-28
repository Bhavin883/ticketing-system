namespace UseCases.TicketUseCase
{
    public class UpdateTicketRequest
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PersonId { get; set; }
        //public ICollection<Note> Notes { get; set; }
    }
}