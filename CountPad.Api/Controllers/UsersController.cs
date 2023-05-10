using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountPad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult> PostUserAsync(User user)
        {
            var response = await _userService.AddUserAsync(user);

            return Ok(response);
        }

        [HttpGet]
        public IQueryable<ActionResult> GetAllUsersAsync()
        {
            var response = _userService.GetAllUsersAsync();

            return (IQueryable<ActionResult>)Ok(response);
        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult> GetUserByIdAsync(Guid id)
        {
            var response = _userService.GetUserByIdAsync(id);

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<ActionResult> UpdateUserAsync(User user)
        {
            var response = _userService.UpdateUserAsync(user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async ValueTask<ActionResult> DeleteUserAsync(Guid id)
        {
            var response = await _userService.DeleteUserAsync(id);

            return Ok(response);
        }
    }
}
