using Microsoft.EntityFrameworkCore;
using TCTest.Domain.UserModel;
using TCTest.Infra;
using TCTest.Infra.Repository;

namespace TCTest.DomainService.Test;

public class PostUserTest : DbInstance
{
    public TCTestDB CreateTcTestDB()
    {
        var _db = new TCTestDB(new DbContextOptionsBuilder<TCTestDB>()
           .UseNpgsql(DbConnectionString)
           .Options);

        return _db;
    }

    [Fact]
    public async Task データを投入()
    {
        // Arrange
        var db = CreateTcTestDB();

        string UserId = "PostUser01";
        string Name = "PostUserName";
        int Age = 50;

        IUserRepository userRepository = new UserRepository(db);
        AddUserDS addUserDS = new AddUserDS(userRepository);
        GetUserAtDS getUserAtDS = new GetUserAtDS(userRepository);

        // Act
        await addUserDS.ExecuteAsync(UserId, Name, Age);

        var addUser = await getUserAtDS.ExecuteAsync(UserId);

        // Assert
        Assert.NotNull(addUser);
        Assert.Equal(UserId, addUser.UserId);
        Assert.Equal(Name, addUser.Name);
        Assert.Equal(Age, addUser.Age);
    }
}