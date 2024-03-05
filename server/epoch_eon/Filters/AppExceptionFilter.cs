using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Prueba.Models.DTOs;

namespace Prueba.Filters
{
    public class AppExceptionFilter : IExceptionFilter
    {
        private Type _exceptionType = typeof(ArgumentException);
        public void OnException(ExceptionContext context)
        {
            var error = new APIErrorResponseDTO();
            error.TraceId = context.HttpContext.TraceIdentifier;
            if (context.Exception.GetType() == _exceptionType)
            {
                error.Error = context.Exception.Message;
                context.Result = new JsonResult(error) { StatusCode = 400 };
                return;
            }
            if (false)
            {

                error.Error = "internal_error";
                context.Result = new JsonResult(error) { StatusCode = 500 };
                return;
            }
            error.Error = context.Exception.Message;
            context.Result = new JsonResult(error) { StatusCode = 500 };
            return;
        }
    }
}
