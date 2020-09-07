using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Security.Authentication;

namespace Imip.Models.Config
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode code = CustomStatusCodeByException(context.Exception);

            var result = new ObjectResult(new
            {
                Code = code,
                context.Exception.Message,
            });

            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = result;
        }

        private HttpStatusCode CustomStatusCodeByException(Exception ex)
        {
            if (ex is AuthenticationException)
            {
                return HttpStatusCode.Unauthorized; // 401
            }

            if (ex is UnauthorizedAccessException)
            {
                return HttpStatusCode.MethodNotAllowed; // 405
            }

            if (ex is Exception)
            {
                return HttpStatusCode.BadRequest; // 400
            }

            return HttpStatusCode.BadRequest;
        }
    }
}
