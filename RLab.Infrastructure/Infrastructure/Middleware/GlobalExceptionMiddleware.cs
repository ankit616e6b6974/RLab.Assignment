using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RLab.Infrastructure.Infrastructure.Exceptions;
using System.Text.Json;

namespace RLab.Infrastructure.Infrastructure.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ExternalApiException ex)
            {
                _logger.LogWarning(ex, ex.Message);

                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = "application/json";

                var errorPayload = JsonSerializer.Serialize(new
                {
                    success = false,
                    message = ex.Message
                });

                await context.Response.WriteAsync(errorPayload);

            }
        }
    }
}
