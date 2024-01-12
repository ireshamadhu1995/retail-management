using Microsoft.AspNetCore.Mvc;
using retail_management.Dtos;
using retail_management.Services;

namespace retail_management.Controllers
{
    // [ApiController]

    //  [Route("api/user")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserController: ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public UserController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginInputDto user)
        {
            var dbUser = await _libraryService.LoginAsync(user);

            if (dbUser == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"incorrect username or pasword");
            }

            return CreatedAtAction("Login", new { id = dbUser.id }, dbUser);
        }
    }
}
