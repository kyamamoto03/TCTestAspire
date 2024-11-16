using Microsoft.EntityFrameworkCore;
using TCTest.Domain.UserModel;
using TCTest.DTO;
using TCTest.Infra;
using TCTest.Infra.Repository;
using TCTest.WebApi.Apis;

namespace TCTest.WebApi.Test;

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
        var UserId = "PostUser01";
        var user = new PostUserRequest
        {
            UserId = UserId,
            Name = "PostUserName",
            Age = 50
        };

        IUserRepository userRepository = new UserRepository(db);
        // Act
        await UserApi.PostUserAsync(user, userRepository);

        var addUser = await UserApi.GetUserAtAsync(UserId, userRepository);

        // Assert
        Assert.NotNull(addUser);
        Assert.Equal(UserId, addUser.UserId);
        Assert.Equal(user.Name, addUser.Name);
        Assert.Equal(user.Age, addUser.Age);
    }
}