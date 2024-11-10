using NasheedAppBack.Entities.Identity;

namespace NasheedAppBack.Entities.Model
{
    public class Playlist
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<NasheedPlaylist> NasheedPlaylists { get; set; }
    }
}
