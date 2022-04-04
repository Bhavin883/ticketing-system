using UseCases.Services;
using UseCases.ViewModels;

namespace UseCases.NoteUseCase
{
    public class DeleteNoteUseCase : IDeleteNoteUseCase

    {
        private readonly INoteService _NoteService;

        public DeleteNoteUseCase(
            INoteService NoteService)
        {
            _NoteService = NoteService;
        }
        public ResponseModel Handle(DeleteNoteRequest request)
        {
            var DeleteNoteResponse = _NoteService.DeleteNote(request.Id,request.IsAdmin);
            return DeleteNoteResponse;
        }
    }
}

