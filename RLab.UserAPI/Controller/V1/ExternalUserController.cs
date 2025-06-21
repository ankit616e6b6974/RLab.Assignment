using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RLab.Interface;

namespace RLab.UserAPI.Controller.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ExternalUserController : ControllerBase
    {
        private readonly IExternalUserService _externalUserService;

        public ExternalUserController(IExternalUserService externalUserService)
        {
            _externalUserService = externalUserService;
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Invalid user ID");

            var result = await _externalUserService.GetUserById(id);
            if (result != null)
            {
                return new JsonResult(result);
            }
            return NoContent();
        }

        [HttpGet("GetUserByPage")]
        public async Task<IActionResult> GetUserByPage([FromQuery] int page)
        {
            if (page <= 0)
                return BadRequest("Invalid page");

            var result = await _externalUserService.GetUserByPage(page);
            if (result != null)
            {
                return new JsonResult(result);
            }
            return NoContent();
        }
    }
}
