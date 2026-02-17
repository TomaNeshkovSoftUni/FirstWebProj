using System;
using System.Collections.Generic;
using System.Text;
using FirstWebServer.Server.HTTP_Request;

namespace FirstWebServer.Server.Responses
{
    public class BadRequestResponse : HTTP_Request.Response
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {
        }
    }
}
