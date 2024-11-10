using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Services.Abstractions;

namespace NasheedAppBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto model)
        {
            CreateUserResponse respone = await _service.CreateUserAsync(model);
            return Ok(respone);
        }

    }
}
