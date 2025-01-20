using System.Collections.Generic;

namespace Product.Application.Wrappers
{
    public class Result<T>
    {
        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public List<string> Errors { get; private set; } = new List<string>();
        public T Data { get; private set; }

        public Result() { }

        public Result(T data, string message = null)
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }
        public Result(string message, List<string> errors = null)
        {
            Succeeded = false;
            Message = message;
            Errors = errors ?? new List<string>();
        }

        public static Result<T> Success(T data, string message = null) =>
            new Result<T>(data, message);

        public static Result<T> Failure(string message, List<string> errors = null) =>
            new Result<T>(message, errors);
    }
}