using TCTest.Domain.UserModel;

namespace TCTest.DomainService;

public interface IDeleteUserDS
{
    Task ExecuteAsync(string userId);
}

public class DeleteUserDS(IUserRepository _userRepository) : IDeleteUserDS
{
    public async Task ExecuteAsync(string userId)
    {
        // 存在確認
        if (await _userRepository.GetUserAsync(userId) == null)
        {
            throw new Exception("User not found.");
        }
        await _userRepository.DeleteUserAsync(userId);
        await _userRepository.UnitOfWork.SaveEntitiesAsync();
    }
}