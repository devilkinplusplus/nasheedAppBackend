using NasheedAppBack.Entities.Model;
using NasheedAppBack.Repositories.Abstractions.Playlists;
using NasheedAppBack.Repositories.Base.Concrete;

namespace NasheedAppBack.Repositories.Concrete.Playlists
{
    public class PlaylistWriteRepository : WriteRepository<Playlist>, IPlaylistWriteRepository
    {
        public PlaylistWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
