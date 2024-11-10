
namespace NasheedAppBack.Entities.Model
{
    public class Nasheed 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string AudioPath { get; set; }
        public string CoverImage { get; set; }

        public ICollection<NasheedPlaylist> NasheedPlaylists { get; set; }
    }
}
