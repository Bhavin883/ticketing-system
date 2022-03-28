using UseCases.ViewModels;

namespace UseCases.NoteUseCase
{
    public interface IDeleteNoteUseCase : IUseCaseHandler<DeleteNoteRequest, ResponseModel>
    {
    }
}
