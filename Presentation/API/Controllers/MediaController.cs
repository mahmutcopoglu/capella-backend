using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("/media")]
        public async Task<IActionResult> AddMedia(IFormFile formFile)
        {
            var result =  await _mediaService.storage(formFile, true);
            return Ok(result);

        }
    }
}
