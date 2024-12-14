using System.Net;
using Crud.Exception.ExceptionModel;

namespace Crud.Api.Middleware
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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

        private static Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            HttpStatusCode statusCode;
            string message;
            List<string> errors = new List<string>();
            
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
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new {
                Message = message,
                StatusCode = (int)statusCode,
                Errors = errors 
            };

            
            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}
