using Common.Entities;
using UseCases.NoteUseCase;

namespace UseCases.Mapper
{
    public class NoteMapper
    {
        public static Note Map(CreateNoteRequest request)
        {
            return new Common.Entities.Note
            {
                Content = request.Content,  
                PersonId = request.PersonId,
                TicketId = request.TicketId
            };
        }
        public static Note Map(UpdateNoteRequest request)
        {
            return new Common.Entities.Note
            {
                Id = request.Id,
                Content = request.Content,
                PersonId = request.PersonId,
                TicketId = request.TicketId
            };
        }
    }
}
