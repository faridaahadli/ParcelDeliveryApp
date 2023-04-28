using System.Net;

namespace Gateway.API.Exceptions
{
    public class CustomException:Exception
    {
        public HttpStatusCode StatusCode { get; }
        public CustomException(string errorMsg, HttpStatusCode statusCode = HttpStatusCode.OK) : base(errorMsg)
        {
            StatusCode = statusCode;
        }
    }
}
