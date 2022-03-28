using UseCases.ViewModels;

namespace UseCases.NoteUseCase
{
    public interface ICreateNoteUseCase : IUseCaseHandler<CreateNoteRequest, ResponseModel>
    {
    }
}
