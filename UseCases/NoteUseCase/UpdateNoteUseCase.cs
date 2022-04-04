using UseCases.Mapper;
using UseCases.Services;
using UseCases.ViewModels;

namespace UseCases.NoteUseCase
{
    public class UpdateNoteUseCase : IUpdateNoteUseCase

    {
        private readonly INoteService _NoteService;

        public UpdateNoteUseCase(
            INoteService NoteService)
        {
            _NoteService = NoteService;
        }
        public ResponseModel Handle(UpdateNoteRequest request)
        {
            var Note = NoteMapper.Map(request);
            var UpdateNoteResponse = _NoteService.UpdateNote(Note);
            return UpdateNoteResponse;
            
        }
    }
}

