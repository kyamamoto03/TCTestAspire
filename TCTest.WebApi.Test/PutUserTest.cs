using Microsoft.EntityFrameworkCore;
using TCTest.DTO;
using TCTest.Infra;
using TCTest.Infra.Repository;
using TCTest.WebApi.Apis;

namespace TCTest.WebApi.Test;

public class PutUserTest : DbInstance
{
    public TCTestDB CreateTcTestDB()
    {
        var _db = new TCTestDB(new DbContextOptionsBuilder<TCTestDB>()
           .UseNpgsql(DbConnectionString)
           .Options);

        return _db;
    }

    [Fact]
    public async Task データの更新()
    {
        // Arrange
        var db = CreateTcTestDB();
        var userRepository = new UserRepository(db);
        var userId = "USER01";

        var putUserRequest = new PutUserRequest
        {
            Name = "Test更新",
            Age = 22
        };
        // Act
        await UserApi.PutUserAsync(userId, putUserRequest, userRepository);

        var user = await UserApi.GetUserAtAsync(userId, userRepository);

        // Assert
        Assert.NotNull(user);
        Assert.Equal("Test更新", user.Name);
        Assert.Equal(22, user.Age);
    }
}