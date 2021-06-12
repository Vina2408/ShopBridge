using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Models.Security
{
    class TokenIOModel
    {
    }

    [ExcludeFromCodeCoverage]
    public class TokenInputModel
    {
        [Required]
        public TokenRole RoleType { get; set; }
    }
    [ExcludeFromCodeCoverage]
    public class TokenOutputModel
    {         
        public string Token { get; set; }
        public string Role { get; set; }
    }

    public enum TokenRole
    {
        Admin = 1,
        User = 2
    }

    [ExcludeFromCodeCoverage]
    public class CommonFailedOutputModel
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}
