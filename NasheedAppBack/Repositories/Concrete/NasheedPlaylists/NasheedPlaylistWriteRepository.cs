using NasheedAppBack.Entities.Model;
using NasheedAppBack.Repositories.Abstractions.NasheedPlaylists;
using NasheedAppBack.Repositories.Base.Concrete;

namespace NasheedAppBack.Repositories.Concrete.NasheedPlaylists
{
    public class NasheedPlaylistWriteRepository : WriteRepository<NasheedPlaylist>, INasheedPlaylistWriteRepository
    {
        public NasheedPlaylistWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
