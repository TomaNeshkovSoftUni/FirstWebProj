using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace WebServer.Server.HTTP_Request
{
    public class Response
    {
        public StatusCode StatusCode { get; init; }
        public HeaderCollection Headers { get;  } = new HeaderCollection();
        public string? Body { get; set; }
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;

            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Data, $"{DateTime.UtcNow:r}");
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"HTTP/1.1 {(int)StatusCode} {StatusCode}");
            foreach (var header in Headers)
            {
                result.AppendLine(header.ToString());
            }
            result.AppendLine();
            if (!string.IsNullOrEmpty(Body))
            {
                result.AppendLine(Body);
            }
            return result.ToString();
        }
    }
}
