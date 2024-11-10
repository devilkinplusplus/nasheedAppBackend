namespace NasheedAppBack.DTOs.ResponseParams
{
    public class CreateUserResponse
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}
