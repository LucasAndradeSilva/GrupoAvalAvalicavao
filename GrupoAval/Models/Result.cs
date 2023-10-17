namespace GrupoAval.Models
{
    public class Result<T>
    {
        public Result(T data, string message, bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class Result
    {
        public Result(string message, bool success = true)
        {
            Message = message;
            Success = success;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
