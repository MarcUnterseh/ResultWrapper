using ResultWrapper.Abstractions;

namespace ResultWrapper;

public static class Result
{
    public static IFailureResult Fail() => new FailureResult();
    public static IFailureResult Fail(Exception exception) => new FailureResult(exception);
    public static IFailureResult Fail(string message) => new FailureResult(message);
    public static IFailureResult Fail(List<string> messages) => new FailureResult(messages);
    public static IFailureResult Fail(Exception exception, string message) => new FailureResult(exception, message);
    public static IFailureResult Fail(Exception exception, List<string> messages) => new FailureResult(exception, messages);

    public static IFailureResult<TData> Fail<TData>() => new FailureResult<TData>();
    public static IFailureResult<TData> Fail<TData>(Exception exception) => new FailureResult<TData>(exception);
    public static IFailureResult<TData> Fail<TData>(string message) => new FailureResult<TData>(message);
    public static IFailureResult<TData> Fail<TData>(List<string> messages) => new FailureResult<TData>(messages);
    public static IFailureResult<TData> Fail<TData>(Exception exception, string message) => new FailureResult<TData>(exception, message);
    public static IFailureResult<TData> Fail<TData>(Exception exception, List<string> messages) => new FailureResult<TData>(exception, messages);


    public static ISuccessResult Success() => new SuccessResult();
    public static ISuccessResult Success(string message) => new SuccessResult(message);
    public static ISuccessResult Success(List<string> messages) => new SuccessResult(messages);

    public static ISuccessResult<TData> Success<TData>(TData data) => new SuccessResult<TData>(data);
    public static ISuccessResult<TData> Success<TData>(TData data, string message) => new SuccessResult<TData>(data, message);
    public static ISuccessResult<TData> Success<TData>(TData data, List<string> messages) => new SuccessResult<TData>(data, messages);
}