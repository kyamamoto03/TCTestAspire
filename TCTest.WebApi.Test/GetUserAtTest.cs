using Microsoft.EntityFrameworkCore;
using TCTest.Infra;
using TCTest.Infra.Repository;
using TCTest.WebApi.Apis;

namespace TCTest.WebApi.Test;

public class GetUserAtTest : DbInstance
{
    public TCTestDB CreateTcTestDB()
    {
        var _db = new TCTestDB(new DbContextOptionsBuilder<TCTestDB>()
           .UseNpgsql(DbConnectionString)
           .Options);

        return _db;
    }

    [Fact]
    public async Task データを1件取得できること()
    {
        // Arrange
        var db = CreateTcTestDB();
        var userRepository = new UserRepository(db);
        var userId = "USER01";
        // Act
        var user = await UserApi.GetUserAtAsync(userId, userRepository);

        // Assert
        Assert.NotNull(user);
        Assert.Equal("Test太郎", user.Name);
        Assert.Equal(20, user.Age);
    }
}