namespace SharedKernel.Common;

public readonly record struct ServiceResult : IServiceResult
{
    public ServiceResult()
    {
        Status = ResponseStatus.Success;
        ErrorException = null;
    }

    public ServiceResult(Exception exception)
    {
        Status = ResponseStatus.Faulted;
        ErrorException = exception;
    }

    public ResponseStatus Status { get; }

    public bool IsSuccess => Status == ResponseStatus.Success;

    public Exception? ErrorException { get; }
}

