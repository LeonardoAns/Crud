using System.Net;
using Crud.Exception.ExceptionModel;

namespace Crud.Api.Middleware
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            HttpStatusCode statusCode;
            string message;
            List<string> errors = new List<string>();
            string? stackTrace = null;  

            if (exception is NotFoundException notFoundException)
            {
                message = notFoundException.Message;
                statusCode = notFoundException.StatusCode;
            }
            else if (exception is InvalidRequestException invalidRequestException)
            {
                message = invalidRequestException.Message;
                statusCode = invalidRequestException.StatusCode;
                errors = invalidRequestException.Errors;
            }
            else
            {
                message = "An unexpected error occurred.";
                statusCode = HttpStatusCode.InternalServerError;
                if (_env.IsDevelopment())
                {
                    stackTrace = exception.StackTrace;  
                }
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                Message = message,
                StatusCode = (int)statusCode,
                Errors = errors,
                StackTrace = stackTrace  
            };

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
