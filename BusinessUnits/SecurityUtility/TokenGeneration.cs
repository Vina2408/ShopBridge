using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessUnits.SecurityUtility
{
    [ExcludeFromCodeCoverage]
    public class TokenGeneration
    {
        IOptions<ConfigurationOptionsModel> _options;
        public TokenGeneration(IOptions<ConfigurationOptionsModel> options)
        {
            _options = options;
        }

        public TokenOutputModel GenerateNewToken(TokenInputModel tokenInputModel)
        {
            TokenOutputModel OutObj = new TokenOutputModel();

            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _options.Value.Jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("role",tokenInputModel.RoleType == TokenRole.Admin ? "Admin" : "User")
                   };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Jwt.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_options.Value.Jwt.Issuer , _options.Value.Jwt.Audience, claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
            
            OutObj.Token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token);
            OutObj.Role = tokenInputModel.RoleType == TokenRole.Admin ? "Admin" : "User";
            
            return OutObj;
        }
    }
}
