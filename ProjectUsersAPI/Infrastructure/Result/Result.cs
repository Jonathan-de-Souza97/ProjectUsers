namespace Infrastructure.Result 
{
    public class Result<T> where T : class
    {
        public bool SucessResult { get; }
        public string Message { get; }
        public T? Data { get; }

        private Result(bool sucessResult, string message, T? data)
        {
            SucessResult = sucessResult;
            Message = message;
            Data = data;
        }

        public static Result<T>Sucess(T data) => new Result<T>(true,"Operação efetuada com sucesso", data);

        public static Result<T> Error(string message) => new Result<T>(false, message, default);
    }
}