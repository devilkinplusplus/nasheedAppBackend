using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NasheedAppBack.Consts;
using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Entities.Identity;
using NasheedAppBack.Services.Abstractions;

namespace NasheedAppBack.Services.Concretes
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }


        public async Task<LoginResponse> LoginAsync(string emailOrUsername, string password)
        {
            User? user = await _userManager.FindByEmailAsync(emailOrUsername);

            if (user is null)
                user = await _userManager.FindByNameAsync(emailOrUsername);

            if (user is null)
                return new() { Succeeded = false, Errors = new List<string> { Messages.LoginFailedMessage } };

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                Token token = await _tokenService.CreateTokenAsync(user);
                return new() { Succeeded = true, Token = token };
            }

            return new() { Succeeded = false, Errors = new List<string> { Messages.PasswordIncorrectMessage } };
        }
    }
}
