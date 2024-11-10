using NasheedAppBack.Entities.Model;
using NasheedAppBack.Repositories.Abstractions.Playlists;
using NasheedAppBack.Repositories.Base.Concrete;

namespace NasheedAppBack.Repositories.Concrete.Playlists
{
    public class PlaylistReadRepository : ReadRepository<Playlist>, IPlaylistReadRepository
    {
        public PlaylistReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
