using System;
using System.Collections.Generic;
using System.Text;
using FirstWebServer.Server.HTTP_Request;

namespace FirstWebServer.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse() 
            : base(StatusCode.NotFound)
        {
        }
    }
}
