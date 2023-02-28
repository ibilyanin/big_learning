namespace SharedKernel.Common;

public readonly record struct ServiceResult<TResult> : IServiceResult<TResult>
{
    public ServiceResult(TResult response)
    {
        Value = response;
        Status = ResponseStatus.Success;
        ErrorException = null;
    }

    public ServiceResult(Exception exception)
    {
        Value = default!;
        Status = ResponseStatus.Faulted;
        ErrorException = exception;
    }

    public TResult Value { get; }

    public ResponseStatus Status { get; }

    public bool IsSuccess => Status == ResponseStatus.Success;

    public Exception? ErrorException { get; }

    public static implicit operator ServiceResult<TResult>(TResult value)
        => new ServiceResult<TResult>(value);
}
