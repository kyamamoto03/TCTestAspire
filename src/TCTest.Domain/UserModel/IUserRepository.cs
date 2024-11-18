using TCTest.Domain.SeedOfWork;

namespace TCTest.Domain.UserModel;

public interface IUserRepository : IRepository<User>
{
    ValueTask<User?> GetUserAsync(string userId);

    ValueTask<User[]> GetUsersAsync();

    ValueTask AddUserAsync(User user);

    ValueTask UpdateUserAsync(string userId, string Name, int Age);

    ValueTask DeleteUserAsync(string userId);
}