using NasheedAppBack.Entities.Model;
using NasheedAppBack.Repositories.Abstractions.NasheedPlaylists;
using NasheedAppBack.Repositories.Base.Concrete;

namespace NasheedAppBack.Repositories.Concrete.NasheedPlaylists
{
    public class NasheedPlaylistReadRepository : ReadRepository<NasheedPlaylist>, INasheedPlaylistReadRepository
    {
        public NasheedPlaylistReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
