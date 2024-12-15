using System.Net;

namespace HotelReservation.Application.Result
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ErrorResult Error { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        public ApiResult(bool success, string message, T data, HttpStatusCode statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        public ApiResult(bool success, string message, T data, ErrorResult error)
        {
            Success = success;
            Message = message;
            Data = data;
            Error = error;
        }

        public static ApiResult<T> SuccesResult(T data, string message = "İşlem Başarılı", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResult<T>(true, message, data, statusCode);
        }

        public static ApiResult<T>FailureResult(ErrorResult error, string message="İşlem Başarısız", HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ApiResult<T>(false, message, default, error);
        }

    }
}
