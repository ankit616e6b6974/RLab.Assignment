using System.Net.Http.Json;
using System.Text.Json;

namespace RLab.Infrastructure.Infrastructure.Exceptions
{
    public static class HttpResponseExtensions
    {
        public static async Task<T?> SafeReadFromJsonAsync<T>(this HttpContent content)
        {
            try
            {
                return await content.ReadFromJsonAsync<T>();
            }
            catch (JsonException ex)
            {
                throw new ExternalApiException("Malformed response from external service.", 502);
            }
        }
    }
}
