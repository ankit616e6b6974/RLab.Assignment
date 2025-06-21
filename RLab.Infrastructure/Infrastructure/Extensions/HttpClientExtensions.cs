using RLab.Infrastructure.Infrastructure.Exceptions;

namespace RLab.Infrastructure.Infrastructure.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> SafeSendAsync(this HttpClient client, string url)
        {
            try
            {
                return await client.GetAsync(url);
            }
            catch (HttpRequestException)
            {
                throw new ExternalApiException("External service unreachable.", 503);
            }
        }
    }
}
