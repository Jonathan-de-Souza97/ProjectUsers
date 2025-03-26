namespace Application.Responses
{
    public class BaseResponse<T> where T : class
    {
        public bool SucessResponse { get; private set; }
        public string Message { get; private set; }
        public T? Data { get; set; }

        private BaseResponse(bool sucessResponse, string message, T? data)
        {
            SucessResponse = sucessResponse;
            Message = message;
            Data = data;
        }

        public static BaseResponse<T> Success (T data, string message = "Operação efetuada com sucesso")
        {
            return new BaseResponse<T>(true,message, data);
        }

        public static BaseResponse<T> Error(string message) 
        {
            return new BaseResponse<T>(false,message, default);
        }
    }
}