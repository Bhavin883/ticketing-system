namespace UseCases.NoteUseCase
{
    public class DeleteNoteRequest
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
