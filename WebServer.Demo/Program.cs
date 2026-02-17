
using FirstWebServer.Server;
using FirstWebServer.Server.Responses;
using FirstWebServer.Server.Views;

namespace FirstWebServer.Demo
{ 
    public class Program
    {
        public static void Main()
        {
            var server = new HttpServer(routes =>
            {
                routes
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/HTML", new HtmlResponse("<h1 style='font-family:sans-serif;background:linear-gradient(90deg,#ff6b6b,#5f27cd);-webkit-background-clip:text;color:transparent'>HTML Response</h1>"))
                .MapGet("/Dominos", new RedirectResponse("https://www.dominos.bg/tracker"))
                .MapGet("/login", new HtmlResponse(Form.HTML));
            });
            server.Start();
        }
    }
}
