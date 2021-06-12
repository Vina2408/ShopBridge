using Models.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessUnits.SecurityUtility
{
    public interface ISecurityUtilityUnitOfWork
    {
        TokenOutputModel GetToken(TokenInputModel tokenInputModel);
    }
}
