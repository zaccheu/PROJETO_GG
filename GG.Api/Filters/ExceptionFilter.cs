using GG.Communication.Responses;
using GG.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GG.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is GGException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnkownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var ggException = (GGException)context.Exception;
        var errorResponse = new ResponseErrorJson(ggException!.GetErros());

        context.HttpContext.Response.StatusCode = ggException.StatusCode;
        context.Result = new BadRequestObjectResult(errorResponse);
    }

    private void ThrowUnkownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("Erro desconhecido.");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
