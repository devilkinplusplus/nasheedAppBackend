namespace NasheedAppBack.DTOs.RequestParams
{
    public class CreatePlaylistDto
    {
        public string Title { get; set; }
        public string UserId { get; set; }
        public IEnumerable<string> NasheedIds { get; set; }
    }
}
