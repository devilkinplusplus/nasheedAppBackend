using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NasheedAppBack.Consts;
using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Entities.Identity;
using NasheedAppBack.Services.Abstractions;
using NasheedAppBack.Validators;

namespace NasheedAppBack.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public UserService(UserManager<User> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserDto model)
        {
            if (await IsEmailExist(model.Email))
                return new() { Succeeded = false, Errors = new() { Messages.AlreadyInUseMessage } };

            ValidationResult vResults = await ValidateUserAsync(model);

            if (vResults.IsValid)
            {
                IdentityResult result = await _userManager.CreateAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Username,
                }, model.Password);

                if (result.Succeeded)
                    return new() { Succeeded = true };
                else
                    return new() { Succeeded = false, Errors = result.Errors.Select(x => x.Description).ToList() };

            }
            return new() { Succeeded = false, Errors = vResults.Errors.Select(x => x.ErrorMessage).ToList() };
        }

        private async Task<ValidationResult> ValidateUserAsync(CreateUserDto user)
        {
            CreateUserValidator validationRules = new();
            ValidationResult result = await validationRules.ValidateAsync(user);
            return result;
        }

        private async Task<bool> IsEmailExist(string email) => await _context.Users.AnyAsync(x => x.Email == email);
    }
}
