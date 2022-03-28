using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.ViewModels;

namespace UseCases.NoteUseCase
{
    public interface IDisplayAllNoteUseCase : IUseCaseHandler<int, List<Note>>
    {
    }
}
