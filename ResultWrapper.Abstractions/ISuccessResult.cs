namespace ResultWrapper.Abstractions;

public interface ISuccessResult : IResult
{ }


public interface ISuccessResult<TData> : IResult, IResult<TData>
{
    TData Data { get; }
}