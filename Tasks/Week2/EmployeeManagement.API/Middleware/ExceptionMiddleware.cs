using System.Net;
using System.Text.Json;

namespace EmployeeManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
                InnerException = exception.InnerException?.Message,
                StackTrace = exception.StackTrace
            };

            return context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}