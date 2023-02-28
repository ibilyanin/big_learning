using SharedKernel.Common;

namespace SharedKernel.Services;
public abstract class BaseCommandHandler
{
    protected ServiceResult<T> Success<T>(T value) => new(value);

    protected ServiceResult<T> Failure<T>(Exception exception) => new(exception);

    protected ServiceResult Success() => new();

    protected ServiceResult Failure(Exception exception) => new(exception);
}
