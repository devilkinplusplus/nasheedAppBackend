using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Entities.Model;

namespace NasheedAppBack.Services.Abstractions
{
    public interface INasheedService
    {
        public Task<NasheedResponse> PostNasheedAsync(NasheedDto nasheedDto);
        public Task<IEnumerable<NasheedResponse>> GetAllNasheedsAsync();

    }
}
