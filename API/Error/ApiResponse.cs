namespace API.Errors

{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageForStatusCode(statusCode);
        }

        private string GetMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "you have made a bad request",
                401 => "you are not authorized",
                404 => "resources not found",
                500 => "errors have been made",
                _ => null,

            };
        }
    }
}
