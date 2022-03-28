using UseCases.Mapper;
using UseCases.Services;
using UseCases.ViewModels;

namespace UseCases.NoteUseCase
{
    public class CreateNoteUseCase : ICreateNoteUseCase

    {
        private readonly INoteService _NoteService;

        public CreateNoteUseCase(
            INoteService NoteService)
        {
            _NoteService = NoteService;
        }
        public IResult<ResponseModel> Handle(CreateNoteRequest request)
        {
            var Note = NoteMapper.Map(request);
            var CreateNoteResponse = _NoteService.CreateNote(Note);
            return Result<ResponseModel>.Success(CreateNoteResponse);
        }
    }
}

