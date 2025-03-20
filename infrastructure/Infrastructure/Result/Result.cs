namespace Infrastructure.Result 
{
    public class Result<T> where T : class
    {
        public bool Sucess { get; }
        public string Message { get; }
        public T? Data { get; }

        private Result(bool sucess, string message, T? data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public static Result<T>Done(T data) => new Result<T>(true,"Operação efetuada com sucesso", data);

        public static Result<T> Error(string message) => new Result<T>(false, message, default);
    }
}