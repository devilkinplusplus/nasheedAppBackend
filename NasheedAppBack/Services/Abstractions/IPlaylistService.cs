using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;

namespace NasheedAppBack.Services.Abstractions
{
    public interface IPlaylistService
    {
        Task<CreatePlaylistResponse> CreatePlaylistAsync(CreatePlaylistDto model);
        Task<IEnumerable<PlaylistDto>> GetUserPlaylistsAsync(string userId);
    }
}
