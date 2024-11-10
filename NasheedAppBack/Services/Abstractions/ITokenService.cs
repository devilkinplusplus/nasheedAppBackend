using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.Entities.Identity;

namespace NasheedAppBack.Services.Abstractions
{
    public interface ITokenService
    {
        Task<Token> CreateTokenAsync(User user);
    }
}
