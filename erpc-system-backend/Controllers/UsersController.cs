using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erpc_system_backend.Models;
using erpc_system_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erpc_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ErpcDbContext context;
        private IUserService _userService;
        public UsersController(ErpcDbContext _context, IUserService userService)
        {
            context = _context;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.HashedPassword);

            return user == null ? Unauthorized(new { message = "Username or password is incorrect" })
                : (IActionResult)Ok(user);
        }
    }
}