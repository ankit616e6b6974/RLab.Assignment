using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace RLab.Infrastructure.Infrastructure.Middleware
{
    public class ResponseCacheMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;
        private readonly int _ttlSeconds;

        public ResponseCacheMiddleware(RequestDelegate next, IMemoryCache cache, IConfiguration config)
        {
            _next = next;
            _cache = cache;
            _config = config;
            _ttlSeconds = config.GetValue<int>("CacheSettings:TTLSeconds", 300);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method != HttpMethods.Get)
            {
                await _next(context);
                return;
            }

            var cacheKey = $"{context.Request.Path}{context.Request.QueryString}".ToLower();

            if (_cache.TryGetValue(cacheKey, out string cachedResponse))
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(cachedResponse);
                return;
            }

            var originalBody = context.Response.Body;
            using var memStream = new MemoryStream();
            context.Response.Body = memStream;

            await _next(context);

            memStream.Position = 0;
            var responseBody = await new StreamReader(memStream).ReadToEndAsync();

            if (context.Response.StatusCode == 200)
            {
                _cache.Set(cacheKey, responseBody, TimeSpan.FromSeconds(_ttlSeconds));
            }

            memStream.Position = 0;
            await memStream.CopyToAsync(originalBody);
            context.Response.Body = originalBody;
        }
    }
}
