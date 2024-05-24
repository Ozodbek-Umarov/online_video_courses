using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineVideoCourse.Aplication.DTOs.UserDTOs;
using OnlineVideoCourse.Aplication.Interfaces;

namespace online_video_courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccauntController(IAcauntService service) : ControllerBase
    {
        private readonly IAcauntService _service = service;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] AddUserDto dto)
        {
            await _service.RegistrAsync(dto);
            return Ok();
        }
        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromForm] LogingDto dto)
        {
            var result = await _service.LoginAsync(dto);
            return Ok($"Token : {result}");
        }
        [HttpPost("sendcode")]
        public async Task<IActionResult> SendCodeAsync([FromForm] string email)
        {
            await _service.SendCodeAsync(email);
            return Ok();
        }
        [HttpPost("check")]
        public async Task<IActionResult> CheckCodeAsync([FromForm] string email, [FromForm] string code)
            => Ok(await _service.CheckCodeAsync(email, code));
    }
}
