using NasheedAppBack.DTOs.ResponseParams;

namespace NasheedAppBack.Services.Abstractions
{
    public interface ISunnahService
    {
        Task CreateSunnahAsync(string content);
        Task<IEnumerable<SunnahResponse>> GetAllSunnahsAsync();
    }
}
