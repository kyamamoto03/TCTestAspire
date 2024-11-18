using TCTest.Domain.UserModel;

namespace TCTest.DomainService;

public interface IGetUserDS
{
    Task<IEnumerable<User>> ExecuteAsync();
}

public class GetUserDS(IUserRepository userRepository) : IGetUserDS
{
    public async Task<IEnumerable<User>> ExecuteAsync()
    {
        var users = await userRepository.GetUsersAsync();
        return users;
    }
}