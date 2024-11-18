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
        var user = await _userRepository.GetUserAsync(userId);
        if (user is null)
        {
            throw new Exception("User not found.");
        }

        return user;
    }
}