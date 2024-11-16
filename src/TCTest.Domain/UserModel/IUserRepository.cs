using TCTest.Domain.SeedOfWork;

namespace TCTest.Domain.UserModel;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserAsync(string userId);

    Task<User[]> GetUsersAsync();

    Task AddUserAsync(User user);

    Task UpdateUserAsync(string userId, string Name, int Age);

    Task DeleteUserAsync(string userId);
}