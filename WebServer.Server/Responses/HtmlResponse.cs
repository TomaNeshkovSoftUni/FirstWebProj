using FirstWebServer.Server.HTTP;
using FirstWebServer.Server.HTTP_Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstWebServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html,
            Action<Request, Response> preRenderAction = null)
            : base(html, ContentType.Html, preRenderAction)
        {
        }
    }
}
