using FirstWebServer.Server.HTTP;
using FirstWebServer.Server.HTTP_Request;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FirstWebServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text,
            Action<Request, Response> preRenderAction = null)
             : base(text, ContentType.PlainText, preRenderAction)
        {
        }
    }
}
