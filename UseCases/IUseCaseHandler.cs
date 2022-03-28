namespace UseCases
{
    public interface IUseCaseHandler<in TIn, TOut>
    {
        IResult<TOut> Handle(TIn request);
    }
}
