using Microsoft.EntityFrameworkCore;
using TCTest.Domain.SeedOfWork;
using TCTest.Domain.UserModel;

namespace TCTest.Infra.Repository;

public class UserRepository(TCTestDB _tcTestDB) : IUserRepository
{
    public IUnitOfWork UnitOfWork => _tcTestDB;

    public async ValueTask AddUserAsync(User user)
    {
        await _tcTestDB.Users.AddAsync(user);
    }

    public async ValueTask DeleteUserAsync(string userId)
    {
        var targetUser = await _tcTestDB.Users.FindAsync(userId);

        if (targetUser == null)
        {
            throw new Exception("User not found");
        }

        _tcTestDB.Users.Remove(targetUser);
    }

    public async ValueTask<User?> GetUserAsync(string userId)
    {
        var user = await _tcTestDB.Users.FindAsync(userId);
        return user;
    }

    public async ValueTask<User[]> GetUsersAsync()
    {
        var users = await _tcTestDB.Users.ToArrayAsync();
        return users;
    }

    public async ValueTask UpdateUserAsync(string userId, string Name, int Age)
    {
        var user = await _tcTestDB.Users.FindAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        user.SetName(Name);
        user.SetAge(Age);
    }
}