using erpc_system_backend.Models;
using erpc_system_backend.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace erpc_system_backend.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly ErpcDbContext context;
        private readonly IOptions<AppKeys> _appSettings;

        public UserService(IOptions<AppKeys> appSettings, ErpcDbContext _context)
        {
            _appSettings = appSettings;
            context = _context;
        }

        public User Authenticate(string email, string password)
        {
            string hashedPss = Hasher.GetHash(password);

            var user = context.Users.SingleOrDefault(x => x.Email == email && x.HashedPassword == hashedPss);

            var membership = context.Memberships.SingleOrDefault(x => x.UserId == user.UserId);

            // return null if user not found
            if (user == null)
                return null;

            //symmetric security key
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.JwtSecret));

            //signin credentials
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

            //Claims 

            IEnumerable<Claim> claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("AccountId", membership.AccountId.ToString())
            };

            //create token
            var token = new JwtSecurityToken(
                issuer: "tuturulabs.in",
                claims: claims,
                audience: "admins",
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials
            );

            // remove password before returning
            user.HashedPassword = null;
            user.Memberships = null;
            user.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return user;
        }
    }
}
