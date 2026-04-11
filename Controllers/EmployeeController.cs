using Microsoft.AspNetCore.Mvc;
using TestingApp.Services;
using TestingApp.ViewModels;

namespace TestingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // CREATE

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(employeeViewModel.Name))
                return BadRequest("Name is required.");
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid");
            }
            var user = await _employeeService.Create(employeeViewModel, cancellationToken);
            employeeViewModel.Id = user.Id;
            return Ok(employeeViewModel);
        }

        // READ ALL
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var users = await _employeeService.GetAll(cancellationToken);
            if (users.Count > 0)
            {
                var employeeViewModels = users.Select(x => new EmployeeViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    MobileNo = x.MobileNo,
                    Department = x.Department,
                    UnitId = x.UnitId,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    IsActive = x.IsActive
                }).ToList();
                return Ok(users);
            }
            return NotFound();
        }

        // READ BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetById(id, cancellationToken);
            if (employee == null)
                return NotFound();

            var employeeViewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                MobileNo = employee.MobileNo,
                Department = employee.Department,
                UnitId = employee.UnitId,
                Address1 = employee.Address1,
                Address2 = employee.Address2,
                IsActive = employee.IsActive
            };
            return Ok(employeeViewModel);
        }

        // UPDATE
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeViewModel employeeViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid");
            }
            var employee = await _employeeService.Update(employeeViewModel, cancellationToken);
            if (employee == null)
                return NotFound();
            return Ok(employeeViewModel);
        }

        // DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            if (await _employeeService.Delete(id, cancellationToken))
                return Ok("Deleted successfully");
            return NotFound();
        }
    }
}
