using System.Collections.Generic;

namespace UseCases
{
    public interface IResult
    {
        List<ErrorBase> Errors { get; set; }
        bool Succeeded { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }

}
