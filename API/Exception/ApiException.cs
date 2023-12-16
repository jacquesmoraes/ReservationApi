namespace API.Exception
{
    public class ApiException : ApiResponse
    {
        public string Details { get; set; }

        public ApiException(int statusCode, string messsage = null, string details = null) : base(statusCode, messsage)
        {
            Details= details;
        }

        
    }
}
