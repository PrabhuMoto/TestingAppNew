using Microsoft.EntityFrameworkCore;
using TestingApp.Data;
using TestingApp.Models;
using TestingApp.ViewModels;

namespace TestingApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly TestingDbContext _context;
        public EmployeeService(TestingDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> Create(EmployeeViewModel employeeViewModel, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = employeeViewModel.Name,
                MobileNo = employeeViewModel.MobileNo,
                Department = employeeViewModel.Department,
                UnitId = employeeViewModel.UnitId,
                Address1 = employeeViewModel.Address1,
                Address2 = employeeViewModel.Address2,
                IsActive = employeeViewModel.IsActive
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(id, cancellationToken);
            if (employee == null)
                return false;
            _context.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Employee>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Employees.ToListAsync(cancellationToken);
        }

        public async Task<Employee?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Employee?> Update(EmployeeViewModel employeeViewModel, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(employeeViewModel.Id, cancellationToken);
            if (employee == null)
                return null;
            employee.Name = employee.Name;
            employee.MobileNo = employeeViewModel.MobileNo;
            employee.Department = employeeViewModel.Department;
            employee.UnitId = employeeViewModel.UnitId;
            employee.Address1 = employeeViewModel.Address1;
            employee.Address2 = employeeViewModel.Address2;
            employee.IsActive = employeeViewModel.IsActive;

            await _context.SaveChangesAsync(cancellationToken);
            return employee;
        }
    }
}
