
using Common.Entities;
using UseCases.Mapper;
using UseCases.Services;
using UseCases.ViewModels;

namespace UseCases.NoteUseCase
{
    public class DisplayNoteUseCase : IDisplayNoteUseCase

    {
        private readonly INoteService _NoteService;

        public DisplayNoteUseCase(
            INoteService NoteService)
        {
            _NoteService = NoteService;
        }
        public Note Handle(int request)
        {
            var DisplayNoteResponse = _NoteService.GetNoteDetailsById(request);
            return DisplayNoteResponse;
        }
    }
}

