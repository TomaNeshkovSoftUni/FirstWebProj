using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using FirstWebServer.Server.Common;
using FirstWebServer.Server.HTTP_Request;

namespace FirstWebServer.Server.HTTP
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType) 
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content);
            Guard.AgainstNull(contentType);

            Headers.Add(Header.ContentType, contentType);
            Body = content;
        }

        public override string ToString()
        {

            var contentLength = Encoding.UTF8.GetByteCount(Body);
            Headers.Add(Header.ContentLength, contentLength.ToString());

            return base.ToString();
        }
    }
}
