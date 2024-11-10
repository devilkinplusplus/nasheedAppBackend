using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NasheedAppBack.DTOs.RequestParams;
using NasheedAppBack.DTOs.ResponseParams;
using NasheedAppBack.Services.Abstractions;

namespace NasheedAppBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NasheedsController : ControllerBase
    {

        private readonly INasheedService _service;
        public NasheedsController(INasheedService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> UploadNasheed(NasheedDto model)
        {
            var res = await _service.PostNasheedAsync(model);
            return Ok(res);
        }

        [HttpGet("nasheeds")]
        public async Task<IActionResult> GetNasheeds()
        {
            IEnumerable<NasheedResponse> res = await _service.GetAllNasheedsAsync();
            return Ok(res);
        }


    }
}
