namespace OrderDeliveryService.API.ApiResponse
{
    public class ApiResponse<T>
    {
        public ICollection<ApiError> Errors { get; set; } = new List<ApiError>();
        public T Data { get; set; }
        public int Code { get; set; }
        public int ListCount { get; set; }
        public bool Success { get => Errors == null || Errors.Count() == 0; }

        public ApiResponse(string message, int code)
        {
            Errors.Add(new ApiError(message));
            Code = code;
        }


        public ApiResponse() { }
        public ApiResponse(T data, int code, int count = 0)
        {
            Data = data;
            Code = code;
            ListCount = count;
        }
    }
}
