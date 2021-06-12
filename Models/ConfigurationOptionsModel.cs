using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Models
{
    [ExcludeFromCodeCoverage]
    public class ConfigurationOptionsModel
    {
        public string AllowedHosts { get; set; }
        public string DefaultConnection { get; set; }
        public Logging Logging { get; set; }
        public Jwt Jwt { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }
    [ExcludeFromCodeCoverage]
    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }
    [ExcludeFromCodeCoverage]
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
