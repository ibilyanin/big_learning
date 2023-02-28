namespace SharedKernel.Common;

public interface IServiceResult<TResult> : IServiceResult
{
    TResult Value { get; }
}

public interface IServiceResult
{
    bool IsSuccess { get; }
    Exception? ErrorException { get; }
    public ResponseStatus Status { get; }
}
