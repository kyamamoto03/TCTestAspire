using TCTest.Domain.UserModel;

namespace TCTest.DomainService;

public interface IGetUserAtDS
{
    Task<User> ExecuteAsync(string userId);
}

public class GetUserAtDS(IUserRepository _userRepository) : IGetUserAtDS
{
    public async Task<User> ExecuteAsync(string userId)
    {
        return await _userRepository.GetUserAsync(userId);
    }
}