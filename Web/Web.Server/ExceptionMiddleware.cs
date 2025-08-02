using System.Net;
using System.Text.Json;

namespace Web.Server
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // continúa la ejecución normal
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new Exception("An unexpected error occurred.");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(errorResponse, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
