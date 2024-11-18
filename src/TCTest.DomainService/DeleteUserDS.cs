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
        await _userRepository.DeleteUserAsync(userId);
        await _userRepository.UnitOfWork.SaveEntitiesAsync();
    }
}