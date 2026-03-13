using System;
using System.Collections.Generic;
using System.Text;
using FirstWebServer.Server.Common;

namespace FirstWebServer.Server.HTTP
{
    public class Session
    {
        public const string SessionCookieName = "MyWebServerSID";
        public const string SessionCurrentDateKey = "CurrentDate";
        public const string SessionUserKey = "AuthenticatedUserId";

        private Dictionary<string, string> data;

        public string Id { get; private set; }
        public string this[string key]
        {
            get { return data[key]; }
            set { data[key] = value; }
        }

        public Session(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            Id = id;
            data = new Dictionary<string, string>();
        }

        public bool ContainsKey(string key)
        {
            return data.ContainsKey(key);
        }
        public void Clear()
        {
            data.Clear();
        }
    }
}
