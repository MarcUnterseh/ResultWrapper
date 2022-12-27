namespace ResultWrapper.Abstractions;

public interface IResult
{
    bool Succeeded { get; }
    List<string> Messages { get; }
}

public interface IResult<TData> { }