using TCTest.Domain.UserModel;

namespace TCTest.DomainService;

public interface IAddUserDS
{
    Task ExecuteAsync(string userId, string name, int age);
}

public class AddUserDS(IUserRepository _userRepository) : IAddUserDS
{
    public async Task ExecuteAsync(string userId, string name, int age)
    {
        await _userRepository.AddUserAsync(new User(userId, name, age));
        await _userRepository.UnitOfWork.SaveEntitiesAsync();
    }
}