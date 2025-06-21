namespace RLab.DTO.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, int statusCode = 200) =>
            new() { Success = true, Data = data, StatusCode = statusCode };

        public static ApiResponse<T> Failure(string error, int statusCode) =>
            new() { Success = false, ErrorMessage = error, StatusCode = statusCode };
    }
}
