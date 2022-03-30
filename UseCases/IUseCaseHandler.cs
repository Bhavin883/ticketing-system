namespace UseCases
{
    public interface IUseCaseHandler<in TIn, TOut>
    {
        TOut Handle(TIn request);
    }
}
