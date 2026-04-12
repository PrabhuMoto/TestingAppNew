using Microsoft.EntityFrameworkCore;
using TestingApp.Data;
using TestingApp.Models;
using TestingApp.ViewModels;

namespace TestingApp.Services
{
    public class ToDoService : IToDoService
    {
        private readonly TestingDbContext _context;
        public ToDoService(TestingDbContext context)
        {
            _context = context;
        }
        public async Task<ToDo> Create(ToDoViewModel toDoViewModel, CancellationToken cancellationToken)
        {
            var toDo = new ToDo
            {
                Name = toDoViewModel.Name,
                Description = toDoViewModel.Description,
                Status = toDoViewModel.Status,
                CreatedDate = toDoViewModel.CreatedDate != null ? toDoViewModel.CreatedDate : DateTime.UtcNow,
                UpdatedDate = toDoViewModel.UpdatedDate
            };
            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync(cancellationToken);
            return toDo;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var toDo = await _context.ToDos.FindAsync(id, cancellationToken);
            if (toDo == null)
                return false;
            _context.Remove(toDo);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<ToDo>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.ToDos.ToListAsync(cancellationToken);
        }

        public async Task<ToDo?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.ToDos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<ToDo?> Update(ToDoViewModel toDoViewModel, CancellationToken cancellationToken)
        {
            var toDo = await _context.ToDos.FindAsync(toDoViewModel.Id, cancellationToken);
            if (toDo == null)
                return null;
            toDo.Name = toDoViewModel.Name;
            toDo.Description = toDoViewModel.Description;
            toDo.Status = toDoViewModel.Status;
            toDo.CreatedDate = toDo.CreatedDate;
            toDo.UpdatedDate = toDoViewModel.UpdatedDate;

            await _context.SaveChangesAsync(cancellationToken);
            return toDo;
        }
    }
}
