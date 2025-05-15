
namespace MockAPI.SharedServices.ExceptionHandling
{
    public class CustomHttpResponseException : Exception
    {
        public int StatusCode { get; }
        public object Value { get; }

        public CustomHttpResponseException(int statusCode, string message): base(message)
        {
            StatusCode = statusCode;
            Value = new { message };
        }
    }
}
