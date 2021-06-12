using Microsoft.Extensions.Options;
using Models;
using Models.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BusinessUnits.SecurityUtility
{
    [ExcludeFromCodeCoverage]
    public class SecurityUtilitiyUOW : ISecurityUtilityUnitOfWork
    {
        private readonly IOptions<ConfigurationOptionsModel> _options; 
        public SecurityUtilitiyUOW(IOptions<ConfigurationOptionsModel> options)
        {
            _options = options;
        }

        public TokenOutputModel GetToken(TokenInputModel tokenInputModel)
        {
            TokenGeneration tokenGeneration = new TokenGeneration(_options);
            return tokenGeneration.GenerateNewToken(tokenInputModel);
        }
    }
}
