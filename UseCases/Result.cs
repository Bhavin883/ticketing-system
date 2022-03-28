using System.Collections.Generic;
using System.Threading.Tasks;

namespace UseCases
{
    public class Result : IResult
    {
        public List<ErrorBase> Errors { get; set; } = new();

        public bool Succeeded { get; set; }

        public static IResult Fail(ErrorBase error)
        {
            return new Result { Succeeded = false, Errors = new List<ErrorBase> { error } };
        }

        public static IResult Fail(List<ErrorBase> errors)
        {
            return new Result { Succeeded = false, Errors = errors };
        }

        public static Task<IResult> FailAsync(ErrorBase error)
        {
            return Task.FromResult(Fail(error));
        }

        public static Task<IResult> FailAsync(List<ErrorBase> errors)
        {
            return Task.FromResult(Fail(errors));
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }

        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }
    }
    public class Result<T> : Result, IResult<T>
    {
        public T Data { get; set; }

        public new static Result<T> Success()
        {
            return new() { Succeeded = true };
        }

        public static Result<T> Success(T data)
        {
            return new() { Succeeded = true, Data = data };
        }

        public new static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }
    }
}
