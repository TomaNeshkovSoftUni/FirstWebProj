using System;
using System.Collections.Generic;
using System.Text;
using FirstWebServer.Server.HTTP_Request;

namespace FirstWebServer.Server.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse() 
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
