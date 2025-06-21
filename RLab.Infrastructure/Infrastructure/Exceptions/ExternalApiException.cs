namespace RLab.Infrastructure.Infrastructure.Exceptions
{
    public class ExternalApiException : Exception
    {
        public int StatusCode { get; }

        public ExternalApiException(string message, int statusCode = 500)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }

}
