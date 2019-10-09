using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erpc_system_backend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AppKeys> appConfig;
        public AuthController(IOptions<AppKeys> appKeys)
        {
            appConfig = appKeys;
        }

        [HttpGet("token")]
        public ActionResult GetToken()
        {
            //symmetric security key
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appConfig.Value.JwtSecret));

            //signin credentials
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

            //create token
            var token = new JwtSecurityToken(
                issuer: "acerolalabs.in",
                audience: "admins",
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials
            );

            

            //return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}