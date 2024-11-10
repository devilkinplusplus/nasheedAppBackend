namespace NasheedAppBack.DTOs.ResponseParams
{
    public class CreatePlaylistResponse
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}
