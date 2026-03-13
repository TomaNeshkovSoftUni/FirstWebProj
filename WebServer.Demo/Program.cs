using System.Text;
using System.Web;
using FirstWebServer.Server;
using FirstWebServer.Server.HTTP;
using FirstWebServer.Server.HTTP_Request;
using FirstWebServer.Server.Responses;
using FirstWebServer.Server.Views;
using FirstWebServer.Server.Views.WebServer.Server.Views;

namespace FirstWebServer.Demo
{
    public class StartUp
    {
        private const string Username = "user";
        private const string Password = "user123";

        public static async Task Main()
        {
            await DownloadWebAsTextFile(Form.FileName, ["https://judge.softuni.org/", "https://softuni.org/"]);

            var server = new HttpServer(routes =>
            {
                routes
                    .MapGet("/", new TextResponse("Hello from the server!"))
                    .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
                    .MapGet("/Redirect", new RedirectResponse("https://www.nytimes.com/games/wordle/index.html"))
                    .MapGet("/TestNameAge", new HtmlResponse(Form.HTML))
                    .MapPost("/TestNameAge", new TextResponse("", AddFormDataAction))
                    .MapGet("/Content", new HtmlResponse(Form.DownloadForm))
                    .MapPost("/Content", new TextFileResponse(Form.FileName))
                    .MapGet("/Cookies", new HtmlResponse("", AddCookiesAction))
                    .MapGet("/Session", new TextResponse("", DisplaySessionInfoAction))
                    .MapGet("/Login", new HtmlResponse(LoginPage.LoginForm))
                    .MapPost("/Login", new HtmlResponse("", LoginAction))
                    .MapGet("/Logout", new HtmlResponse("", LogoutAction))
                    .MapGet("/UserProfile", new HtmlResponse("", GetUserDataAction));
            });

            await server.Start();
        }

        private static void AddFormDataAction(Request request, Response response)
        {
            var result = new StringBuilder();

            foreach (var (key, value) in request.FromData)
            {
                result.AppendLine($"{key} - {value}");
            }

            response.Body = result.ToString();
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var html = await response.Content.ReadAsStringAsync();

                int length = Math.Min(html.Length, 2000);
                return html.Substring(0, length);
            }
        }

        private static async Task DownloadWebAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var results = await Task.WhenAll(downloads);

            var combinedContent = string.Join(
                Environment.NewLine + new string('-', 100) + Environment.NewLine,
                results);

            await File.WriteAllTextAsync(fileName, combinedContent);
        }

        private static void AddCookiesAction(Request request, Response response)
        {
            bool hasUserCookies = request.Cookies.Any(c => c.Name != Session.SessionCookieName);

            if (hasUserCookies)
            {
                var sb = new StringBuilder("<h1>Cookies</h1>");
                sb.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    sb.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                response.Body = sb.ToString();
            }
            else
            {
                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
                response.Body = "<h1>Cookies set!</h1>";
            }
        }

        private static void DisplaySessionInfoAction(Request request, Response response)
        {
            bool isFound = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            if (isFound)
            {
                var date = request.Session[Session.SessionCurrentDateKey];
                response.Body = $"Stored data: {date}!";
            }
            else
            {
                response.Body = "Current date stored!";
            }
        }

        private static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();

            var enteredUser = request.FromData["Username"];
            var enteredPass = request.FromData["Password"];

            if (enteredUser == Username && enteredPass == Password)
            {
                request.Session[Session.SessionUserKey] = "MyUserId";
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);
                response.Body = "<h3>Logged successfully! </h3>";
            }
            else
            {
                response.Body = LoginPage.LoginForm;
            }
        }

        private static void LogoutAction(Request request, Response response)
        {
            request.Session.Clear();
            response.Body = "<h3>Logged out successfully!</h3>";
        }

        private static void GetUserDataAction(Request request, Response response)
        {
            if (request.Session.ContainsKey(Session.SessionUserKey))
            {
                response.Body = $"<h3>Currently logged-in user is with username '{Username}'</h3>";
            }
            else
            {
                response.Body = "<h3>You should first log in - <a href='/Login'>Login</a></h3>";
            }
        }
    }
}
