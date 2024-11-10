using NasheedAppBack.DTOs.RequestParams;

namespace NasheedAppBack.DTOs.ResponseParams
{
    public class LoginResponse
    {
        public bool Succeeded { get; set; }
        public Token Token { get; set; }
        public List<string> Errors { get; set; }
    }
}
