using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Services.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NasheedAppBack.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _service;
        public PlaylistsController(IPlaylistService service) => _service = service;


        [HttpPost]
        public async Task<IActionResult> Create(CreatePlaylistDto model)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            model.UserId = id;

            CreatePlaylistResponse res = await _service.CreatePlaylistAsync(model);
            return Ok(res);
        }

        [HttpGet("/myPlaylists")]
        public async Task<IActionResult> GetAll()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            IEnumerable<PlaylistDto> model = await _service.GetUserPlaylistsAsync(id);
            return Ok(model);
        }


    }
}
