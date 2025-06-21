using Polly;
using Polly.Extensions.Http;

namespace RLab.Infrastructure.Infrastructure.Resilience
{
    public static class ResiliencePolicies
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() =>
            HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retry =>
                    TimeSpan.FromSeconds(Math.Pow(2, retry)) + TimeSpan.FromMilliseconds(Random.Shared.Next(0, 100)));

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() =>
            HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
    }
}
