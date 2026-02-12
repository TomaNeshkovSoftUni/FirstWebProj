using WebServer.Server;
using WebServer.Server.Responses;

namespace WebServer.demo
{ 
    public class Program
    {
        public static void Main()
        {
            var server = new HttpServer(x =>
            x.MapGet("/", new TextResponse("<h1 style=\"color:blue;\">Hello from my html response!</h1>"))
            .MapGet("/", new TextResponse("Hello from my server, now with routing table!!!")));

            server.Start();
        }
    }
}
