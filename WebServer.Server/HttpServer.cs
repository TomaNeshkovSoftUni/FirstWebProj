using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FirstWebServer.Server.Contracts;
using FirstWebServer.Server.HTTP;
using FirstWebServer.Server.HTTP_Request;

namespace FirstWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {

            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            serverListener = new TcpListener(this.ipAddress, port);

            routingTableConfiguration(routingTable = new RoutingTable());

        }

        public HttpServer(int port , Action<IRoutingTable> routes)
            : this("127.0.0.1", port, routes)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(8080, routingTable)
        {
        }

        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests ... ");
            while (true)
            {
                var connection = serverListener.AcceptTcpClient();
                var networkStream = connection.GetStream();
                var requestText = ReadRequest(networkStream);
                Console.WriteLine(requestText);
                var request = Request.Parse(requestText);
                var response = routingTable.MatchRequest(request);
                WriteResponse(networkStream, response);
                connection.Close();
            }
        }
        private void WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var requestBuilder = new StringBuilder();
            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
