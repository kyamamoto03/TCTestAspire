using TCTest.Domain.UserModel;

namespace TCTest.DomainService;

public interface IUpdateUserDS
{
    Task ExecuteAsync(string userId, string name, int age);
}

public class UpdateUserDS(IUserRepository _userRepository) : IUpdateUserDS
{
    public async Task ExecuteAsync(string userId, string name, int age)
    {
        await _userRepository.UpdateUserAsync(userId, name, age);
        await _userRepository.UnitOfWork.SaveEntitiesAsync();
    }
}