using Microsoft.AspNetCore.Mvc;
using TestingApp.Services;
using TestingApp.ViewModels;

namespace TestingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "toDos")]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDosController(IToDoService service)
        {
            _service = service;
        }

        // CREATE

        [HttpPost]
        public async Task<IActionResult> Create(ToDoViewModel viewModel, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(viewModel.Name))
                return BadRequest("Name is required.");
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid");
            }
            var todo = await _service.Create(viewModel, cancellationToken);
            viewModel.Id = todo.Id;
            return Ok(viewModel);
        }

        // READ ALL
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var toDos = await _service.GetAll(cancellationToken);
            if (toDos.Count > 0)
            {
                var toDoViews = toDos.Select(x => new ToDoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).ToList();
                return Ok(toDoViews);
            }
            return NotFound();
        }

        // READ BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var toDo = await _service.GetById(id, cancellationToken);
            if (toDo == null)
                return NotFound();

            var toDoView = new ToDoViewModel
            {
                Id = toDo.Id,
                Name = toDo.Name,
                Description = toDo.Description,
                Status = toDo.Status,
                CreatedDate = toDo.CreatedDate,
                UpdatedDate = toDo.UpdatedDate
            };
            return Ok(toDoView);
        }

        // UPDATE
        [HttpPut]
        public async Task<IActionResult> Update(ToDoViewModel viewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid");
            }
            var toDo = await _service.Update(viewModel, cancellationToken);
            if (toDo == null)
                return NotFound();
            return Ok(toDo);
        }

        // DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            if (await _service.Delete(id, cancellationToken))
                return Ok("Deleted successfully");
            return NotFound();
        }
    }
}
