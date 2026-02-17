using System;
using System.Collections.Generic;
using System.Text;
using FirstWebServer.Server.HTTP;

namespace FirstWebServer.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string HTML) 
            : base(HTML, ContentType.Html)
        {
        }
    }
}
