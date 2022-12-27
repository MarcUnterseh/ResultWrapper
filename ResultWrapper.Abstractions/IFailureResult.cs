namespace ResultWrapper.Abstractions;

public interface IFailureResult : IResult
{
    Exception? Exception { get; }
}

public interface IFailureResult<TData> : IFailureResult, IResult<TData>
{
}