using System;
using System.Collections.Generic;
using System.Text;
using FirstWebServer.Server.Common;

namespace FirstWebServer.Server.HTTP
{
    public class Cookie
    {
        public string Name { get; init; }
        public string Value { get; init; }
        public Cookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
