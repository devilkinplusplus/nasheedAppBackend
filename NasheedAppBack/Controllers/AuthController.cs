using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Services.Abstractions;

namespace NasheedAppBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service) => _service = service;


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            LoginResponse response = await _service.LoginAsync(model.UsernameOrEmail,model.Password);
            return Ok(response);
        }

    }
}
