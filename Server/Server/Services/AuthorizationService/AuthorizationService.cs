using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.AuthorizationService
{
    public class AuthorizationService
    {
        private readonly  IAccounts _accounts;
        private readonly ILogger<AuthorizationService> _logger;

        public AuthorizationService(IAccounts accounts, ILogger<AuthorizationService> logger)
        {
            _accounts = accounts;
            _logger = logger;

        }
        public async Task<List<string>> CreateToken(string login, string password)
        {
            var identity = await GetIdentity(login, password);

            if (identity == null) return null;

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                                            SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            List<string> response = new List<string>()
            {
                encodedJwt,
                identity.Name,
            };

            return response;
        }

        //Hash-Password для того чтобы зашифровать данные в базе данных на случай ее кражи 
        //Hash-Salt для уникальности Hash-password
        private async Task<ClaimsIdentity> GetIdentity(string login, string password)
        {
            User user = await _accounts.GetUser()
            if (user != null)
            {
                var claims = new List<Claim>
                {
                  //  new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
