using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.Services.Abstractions;

namespace NasheedAppBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunnahsController : ControllerBase
    {
        private readonly ISunnahService _service;
        public SunnahsController(ISunnahService service) => _service = service;


        [HttpPost]
        public async Task<IActionResult> Create(CreateSunnahDto model)
        {
            await _service.CreateSunnahAsync(model.Content);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _service.GetAllSunnahsAsync();
            return Ok(res);
        }
        

    }
}
