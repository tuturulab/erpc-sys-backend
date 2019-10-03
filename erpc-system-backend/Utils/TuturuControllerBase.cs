using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace erpc_system_backend.Utils
{
    public class TuturuControllerBase : ControllerBase
    {
        public JwtSecurityToken GetTokenReadable()
        {
            string jwt = Request.Headers["Authorization"].FirstOrDefault().Split(' ').LastOrDefault();
            var handler = new JwtSecurityTokenHandler();

            return handler.ReadJwtToken(jwt);


        }
    }
}
