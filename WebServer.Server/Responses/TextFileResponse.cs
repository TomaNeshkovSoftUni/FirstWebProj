using FirstWebServer.Server.HTTP_Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstWebServer.Server.Responses
{
    public class TextFileResponse : Response
    {
        public string FileName { get; init; }
        public TextFileResponse(string fileName) : base(StatusCode.OK)
        {
            FileName = fileName;
            this.Headers.Add(Header.ContentType, HTTP.ContentType.PlainText);
        }

        public override string ToString()
        {
            if (File.Exists(FileName))
            {
                Body = File.ReadAllText(FileName);
                var fileBytesCount = new FileInfo(FileName).Length;
                this.Headers.Add(Header.ContentLength, fileBytesCount.ToString());
                this.Headers.Add(Header.ContentDisposition, $"attachment: filename=\"{this.FileName}\"");
            }
            return base.ToString();
        }
    }
}
