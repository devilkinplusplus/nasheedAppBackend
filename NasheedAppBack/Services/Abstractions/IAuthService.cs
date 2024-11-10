using NasheedAppBack.DTOs.ResponseParams;

namespace NasheedAppBack.Services.Abstractions
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(string emailOrUsername, string password);
    }
}
