using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Common;
using SharedKernel.Exceptions;

namespace Elang.Api.Extensions;

internal static class ServiceResponseExtensions
{
    public static ActionResult ToFaultResult(this IServiceResult serviceResponse) =>
        serviceResponse.ErrorException switch
        {
            ValidationException => new BadRequestObjectResult(serviceResponse.ErrorException.ToString()),
            EntityNotFoundException => new NotFoundResult(),
            _ => new StatusCodeResult(500)
        };
}
