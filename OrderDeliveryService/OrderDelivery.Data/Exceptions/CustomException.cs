using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Data.Exceptions
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
