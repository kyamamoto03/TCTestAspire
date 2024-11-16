using Microsoft.EntityFrameworkCore;
using TCTest.Domain.SeedOfWork;
using TCTest.Domain.UserModel;

namespace TCTest.Infra.Repository;

public class UserRepository(TCTestDB _tcTestDB) : IUserRepository
{
    public IUnitOfWork UnitOfWork => _tcTestDB;

    public Task AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<User[]> GetUsersAsync()
    {
        var users = await _tcTestDB.Users.ToArrayAsync();
        return users;
    }

    public Task UpdateUserAsync(string userId, string Name, int Age)
    {
        throw new NotImplementedException();
    }
}