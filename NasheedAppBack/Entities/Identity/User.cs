using Microsoft.AspNetCore.Identity;
using NasheedAppBack.Entities.Model;

namespace NasheedAppBack.Entities.Identity
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
