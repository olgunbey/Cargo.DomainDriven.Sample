using System.Text.Json.Serialization;

namespace DomainDriven.Sample.API.Common
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
        public static ResponseDto<T> Success(T data, int statusCode = 200)
        {
            return new ResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode
            };
        }
        public static ResponseDto<T> Success(int statusCode = 200)
        {
            return new ResponseDto<T>
            {
                StatusCode = statusCode
            };
        }
        public static ResponseDto<T> Fail(List<string> errors, int statusCode = 400)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode
            };
        }
        public static ResponseDto<T> Fail(string error, int statusCode = 400)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string> { error },
                StatusCode = statusCode
            };
        }
    }
}
