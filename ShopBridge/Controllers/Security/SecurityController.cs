using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BusinessUnits.SecurityUtility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Security;

namespace ShopBridge.Controllers.Security
{
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityUtilityUnitOfWork _securityUtilityUnitOfWork;
        public SecurityController(ISecurityUtilityUnitOfWork securityUtilityUnitOfWork)
        {
            _securityUtilityUnitOfWork = securityUtilityUnitOfWork;
        }

        /// <summary>
        /// 1. Admin
        /// 2. User
        /// </summary>
        /// <param name="tokenInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetToken")]
        public IActionResult GetToken(TokenInputModel tokenInputModel)
        {
            var obj = _securityUtilityUnitOfWork.GetToken(tokenInputModel);
            if (obj != null && !string.IsNullOrEmpty(obj.Role))
                return Ok(obj);
            else
                return BadRequest(new CommonFailedOutputModel { StatusCode = 0, StatusMessage = "Something went wrong. Please contact administrator" });
        }
    }
}