using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Proyecto1.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Excepción de negocio capturada");
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción inesperada");
                await HandleExceptionAsync(httpContext, "Ha ocurrido un error inesperado.", HttpStatusCode.InternalServerError);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new { error = message };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
