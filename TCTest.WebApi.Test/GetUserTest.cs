using Microsoft.EntityFrameworkCore;
using TCTest.Infra;
using TCTest.Infra.Repository;
using TCTest.WebApi.Apis;

namespace TCTest.WebApi.Test;

public class GetUserTest : DbInstance
{
    public TCTestDB CreateTcTestDB()
    {
        var _db = new TCTestDB(new DbContextOptionsBuilder<TCTestDB>()
           .UseNpgsql(DbConnectionString)
           .Options);

        return _db;
    }

    [Fact]
    public async Task 全件取得_1件以上データがあること()
    {
        // Arrange
        var db = CreateTcTestDB();

        // Act
        var users = await UserApi.GetUserAsync(new UserRepository(db));

        // Assert
        Assert.NotNull(users);
    }
}