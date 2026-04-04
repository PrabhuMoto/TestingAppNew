using Microsoft.EntityFrameworkCore;
using TestingApp.Data;
using TestingApp.Models;
using TestingApp.ViewModels;

namespace TestingApp.Services;
public class UserService : IUserService
{
    private readonly TestingDbContext _context;
    public UserService(TestingDbContext dbContext)
    {
        _context = dbContext;
    }
    public async Task<User> Create(UserViewModel userViewModel, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = userViewModel.Name,
            Role = userViewModel.Role
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(id, cancellationToken);
        if (user == null)
            return false;
        _context.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<User>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Users.ToListAsync(cancellationToken);
    }

    public async Task<User?> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<User?> Update(UserViewModel userViewModel, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(userViewModel.Id, cancellationToken);
        if (user == null)
            return null;
        user.Name = userViewModel.Name;
        user.Role = userViewModel.Role;
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }
}