using ResultWrapper.Abstractions;

namespace ResultWrapper;

internal class FailureResult : IFailureResult
{
    internal FailureResult() {}
    internal FailureResult(Exception exception) => Exception = exception ?? throw new ArgumentNullException(nameof(exception));

    internal FailureResult(string message)
    {
        if (message == null) 
            throw new ArgumentNullException(nameof(message));

        Messages.Add(message);
    }

    internal FailureResult(List<string> messages)
    {
        if (messages == null) 
            throw new ArgumentNullException(nameof(messages));

        Messages.AddRange(messages);
    }

    internal FailureResult(Exception exception, string message) : this(exception)
    {
        if (message == null) 
            throw new ArgumentNullException(nameof(message));

        Messages.Add(message);
    }

    internal FailureResult(Exception exception, List<string> messages) : this(exception)
    {
        if (messages == null) 
            throw new ArgumentNullException(nameof(messages));

        Messages.AddRange(messages);
    }

    public Exception? Exception { get; }

    public bool Succeeded => false;
    public List<string> Messages { get; } = new();
}

internal class FailureResult<TData> : FailureResult, IFailureResult<TData>
{
    internal FailureResult() : base() { } 
    internal FailureResult(Exception exception) : base(exception) { }
    internal FailureResult(string message) : base(message) { }
    internal FailureResult(List<string> messages) : base(messages) { }
    internal FailureResult(Exception exception, string message) : base(exception, message) { }
    internal FailureResult(Exception exception, List<string> messages) : base(exception, messages) { }
}