using Common.Entities;
using UseCases.NoteUseCase;

namespace AareonTechnicalTest.Mapper
{
    public class NoteMapper
    {
        public static UpdateNoteRequest GetUpdateNote(Note note)
        {
            var noteUpdate =  new UpdateNoteRequest();
            noteUpdate.Id = note.Id;
            noteUpdate.TicketId = note.TicketId;
            noteUpdate.PersonId = note.PersonId;
            noteUpdate.Content = note.Content;

            return noteUpdate;
        }
    }
}
