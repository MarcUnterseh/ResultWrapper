using ResultWrapper.Abstractions;

namespace ResultWrapper;

internal class SuccessResult : ISuccessResult
{
    internal SuccessResult() {}
    internal SuccessResult(string message) => Messages.Add(message);
    internal SuccessResult(List<string> messages) => Messages.AddRange(messages);
    
    public bool Succeeded => true;
    public List<string> Messages { get; } = new();
}

internal class SuccessResult<TData> : SuccessResult, ISuccessResult<TData>
{
    internal SuccessResult(TData data) => Data = data;
    internal SuccessResult(TData data, string message) : base(message) => Data = data;
    internal SuccessResult(TData data, List<string> messages) : base(messages) => Data = data;

    public TData Data { get; }
}