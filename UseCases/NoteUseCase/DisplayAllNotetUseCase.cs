
using System.Collections.Generic;
using Common.Entities;
using UseCases.Services;

namespace UseCases.NoteUseCase
{
    public class DisplayAllNoteUseCase : IDisplayAllNoteUseCase

    {
        private readonly INoteService _NoteService;

        public DisplayAllNoteUseCase(
            INoteService NoteService)
        {
            _NoteService = NoteService;
        }
        public IResult<List<Note>> Handle(int request)
        {
            var DisplayNoteResponse = _NoteService.GetNoteList();
            return Result<List<Note>>.Success(DisplayNoteResponse);
        }
    }
}

