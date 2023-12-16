namespace API.Errors
{
    public class ApiValidationExceptionResponse : ApiResponse
    {

        public IEnumerable<string> Errors { get; set; }
        public ApiValidationExceptionResponse() : base(400)
        {
        }
    }
}
