using System;
using System.Collections.Generic;
using System.Text;

namespace FirstWebServer.Server.Views
{
    public static class Form
    {
        public const string HTML = @"<!DOCTYPE html>
<html>
<head>
    <title>Contact Us</title>
    <style>
        body { font-family: Arial, sans-serif; }
        .container { width: 400px; margin: 40px auto; }
        .field { margin-bottom: 15px; }
        label { display: block; margin-bottom: 5px; }
        input, textarea, select { width: 100%; padding: 6px; }
        button { padding: 8px 15px; }
    </style>
</head>
<body>
    <div class=""container"">
        <h2>Contact Form</h2>
        <form id=""contactForm"" method=""post"">
            
            <div class=""field"">
                <label for=""fullName"">Full Name:</label>
                <input type=""text"" id=""fullName"" name=""fullName"" required>
            </div>

            <div class=""field"">
                <label for=""phone"">Phone Number:</label>
                <input type=""tel"" id=""phone"" name=""phone"">
            </div>

            <div class=""field"">
                <label for=""subject"">Subject:</label>
                <select id=""subject"" name=""subject"">
                    <option value=""support"">Support</option>
                    <option value=""sales"">Sales</option>
                    <option value=""feedback"">Feedback</option>
                </select>
            </div>

            <div class=""field"">
                <label for=""details"">Details:</label>
                <textarea id=""details"" name=""details"" rows=""5""></textarea>
            </div>

            <div class=""field"">
                <input type=""checkbox"" id=""subscribe"" name=""subscribe"">
                <label for=""subscribe"">Subscribe to newsletter</label>
            </div>

            <button type=""submit"">Send Message</button>
        </form>
    </div>
</body>
</html>";
    }
}
