using TestingApp.Models;
using TestingApp.ViewModels;

namespace TestingApp.Services
{
    public interface IToDoService
    {
        Task<ToDo> Create(ToDoViewModel toDoViewModel, CancellationToken cancellationToken);
        Task<ToDo?> Update(ToDoViewModel toDoViewModel, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<ToDo?> GetById(int id, CancellationToken cancellationToken);
        Task<List<ToDo>> GetAll(CancellationToken cancellationToken);
    }
}
