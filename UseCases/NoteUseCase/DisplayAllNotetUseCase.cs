
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
        public List<Note> Handle(int request)
        {
            var DisplayNoteResponse = _NoteService.GetNoteList();
            return DisplayNoteResponse;
        }
    }
}

