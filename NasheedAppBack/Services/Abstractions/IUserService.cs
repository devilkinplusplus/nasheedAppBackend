using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;

namespace NasheedAppBack.Services.Abstractions
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserDto model);
    }
}
