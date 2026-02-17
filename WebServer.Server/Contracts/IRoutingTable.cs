using System;
using System.Collections.Generic;
using System.Text;
using FirstWebServer.Server.HTTP_Request;

namespace FirstWebServer.Server.Contracts
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, Method method, Response response);
        IRoutingTable MapGet(string url, Response response);
        IRoutingTable MapPost(string url, Response response);
    }
}
