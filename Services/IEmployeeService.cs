using TestingApp.Models;
using TestingApp.ViewModels;

namespace TestingApp.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Create(EmployeeViewModel employeeViewModel, CancellationToken cancellationToken);
        Task<Employee?> Update(EmployeeViewModel employeeViewModel, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<Employee?> GetById(int id, CancellationToken cancellationToken);
        Task<List<Employee>> GetAll(CancellationToken cancellationToken);
    }
}
