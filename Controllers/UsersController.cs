using Microsoft.AspNetCore.Mvc;
using TestingApp.Services;
using TestingApp.ViewModels;

namespace TestingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // CREATE

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel userViewModel, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(userViewModel.Name))
                return BadRequest("Name is required.");
            var user = await _userService.Create(userViewModel, cancellationToken);
            userViewModel.Id = user.Id;
            return Ok(userViewModel);
        }

        // READ ALL
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAll(cancellationToken);
            if (users.Count > 0)
            {
                var userViewModels = users.Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Role = x.Role
                }).ToList();
                return Ok(users);
            }
            return NotFound();
        }

        // READ BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetById(id, cancellationToken);
            if (user == null)
                return NotFound();

            var userModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };
            return Ok(userModel);
        }

        // UPDATE
        [HttpPut]
        public async Task<IActionResult> Update(UserViewModel userViewModel, CancellationToken cancellationToken)
        {
            var user = await _userService.Update(userViewModel, cancellationToken);
            if (user == null)
                return NotFound();
            return Ok(userViewModel);
        }

        // DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            if (await _userService.Delete(id, cancellationToken))
                return Ok("Deleted successfully");
            return NotFound();
        }
    }
}
