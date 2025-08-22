using System.Text.Json.Serialization;

namespace DomainDriven.Sample.API.Common
{
    public class Result<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
        public static Result<T> Success(T data, int statusCode = 200)
        {
            return new Result<T>
            {
                Data = data,
                StatusCode = statusCode
            };
        }
        public static Result<T> Success(int statusCode = 200)
        {
            return new Result<T>
            {
                StatusCode = statusCode
            };
        }
        public static Result<T> Fail(List<string> errors, int statusCode = 400)
        {
            return new Result<T>
            {
                Errors = errors,
                StatusCode = statusCode
            };
        }
        public static Result<T> Fail(string error, int statusCode = 400)
        {
            return new Result<T>
            {
                Errors = new List<string> { error },
                StatusCode = statusCode
            };
        }
    }
}
