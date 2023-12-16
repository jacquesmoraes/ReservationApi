using System.Runtime.Versioning;

namespace API.Exception
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Messsage { get; set; }

        public ApiResponse(int statusCode, string messsage = null)
        {
            StatusCode = statusCode;
            Messsage = messsage ?? GetMessageForStatusCode(statusCode);
        }

        private string GetMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "you have made a bad request",
                401 => "you are not authorized, thats is shame",
                404 => "ressources not found",
                500 => "errors, have been made",
                _ => null,

            };
        }
    }
}
