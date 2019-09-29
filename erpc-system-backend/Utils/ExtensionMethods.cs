using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace erpc_system_backend.Utils
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns CompanyId from request´s token
        /// </summary>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        public static string GetCompanyId(this JwtSecurityToken token)
        {
            Claim claim = token.Claims.ToArray().GetValue(1) as Claim;

            return claim.Value;
        }

        /// <summary>
        /// Returns UserId from request´s token
        /// </summary>
        /// <param name="token">Session token</param>
        /// <returns></returns>
        public static string GetUserId(this JwtSecurityToken token)
        {
            Claim claim = token.Claims.ToArray().GetValue(0) as Claim;

            return claim.Value;
        }
    }
}
