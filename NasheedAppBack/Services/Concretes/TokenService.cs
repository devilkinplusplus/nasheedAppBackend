using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.Entities.Identity;
using NasheedAppBack.Services.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NasheedAppBack.Services.Concretes
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public TokenService(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }


        public async Task<Token> CreateTokenAsync(User user)
        {
            Token token = new();
            token.Expiration = DateTime.UtcNow.AddHours(5);

            SymmetricSecurityKey symmetricSecurity = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new(symmetricSecurity, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new(
                    audience: _configuration["Token:Audience"],
                    issuer: _configuration["Token:Issuer"],
                    expires: token.Expiration,
                    notBefore: DateTime.UtcNow,
                    signingCredentials: credentials,
                    claims: await AddUserValuesToTokenAsync(user)
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }

        private async Task<List<Claim>> AddUserValuesToTokenAsync(User user)
        {
            //var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            //foreach (string role in userRoles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            return claims;
        }

    }
}
