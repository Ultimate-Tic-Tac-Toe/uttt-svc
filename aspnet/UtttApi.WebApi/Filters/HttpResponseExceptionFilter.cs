using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UtttApi.ObjectModel.Exceptions;

namespace UtttApi.WebApi.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { /* No need to do anything before execution */ }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = exception.StatusCode,
                };
                context.ExceptionHandled = true;
            }
        }
    }
}