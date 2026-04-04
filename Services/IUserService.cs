using TestingApp.Models;
using TestingApp.ViewModels;

namespace TestingApp.Services;
public interface IUserService
{
    Task<User> Create(UserViewModel userViewModel, CancellationToken cancellationToken);
    Task<User?> Update(UserViewModel userViewModel, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
    Task<User?> GetById(int id, CancellationToken cancellationToken);
    Task<List<User>> GetAll(CancellationToken cancellationToken);
}