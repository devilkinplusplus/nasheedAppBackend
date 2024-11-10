using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.Entities.Model;

namespace NasheedAppBack.DTOs.ResponseParams
{
    public class PlaylistDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<NasheedDto> Nasheeds { get; set; }
    }
}
