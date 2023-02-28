using Microsoft.AspNetCore.Mvc;
using SharedKernel.Common;

namespace Elang.Api.Common;

public class ElangControllerBase : ControllerBase
{
    protected ActionResult NoContentOrFault(ServiceResult serviceResult)
    {
        return serviceResult.IsSuccess ? NoContent() : serviceResult.ToFaultResult();
    }

    public ActionResult<T> OkOrFault<T>(ServiceResult<T> serviceResult)
    {
        return serviceResult.IsSuccess ? Ok(serviceResult.Value) : serviceResult.ToFaultResult();
    }

    public ActionResult<TResult> CreatedOrFault<TResult, TId>(ServiceResult<TResult> serviceResult, string getActionName, TId id)
    {
        return serviceResult.IsSuccess ? CreatedAtAction(getActionName,
                                                  new { id },
                                                  serviceResult.Value)
                                       : serviceResult.ToFaultResult();
    }
}
