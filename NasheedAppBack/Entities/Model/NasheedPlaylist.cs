namespace NasheedAppBack.Entities.Model
{
    public class NasheedPlaylist
    {
        public string PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public string NasheedId { get; set; }
        public Nasheed Nasheed { get; set; }
    }
}
