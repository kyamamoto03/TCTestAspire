using Microsoft.EntityFrameworkCore;
using TCTest.Infra;
using TCTest.Infra.Repository;

namespace TCTest.DomainService.Test;

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

        GetUserAtDS getUserAtDS = new GetUserAtDS(userRepository);
        // Act
        var user = await getUserAtDS.ExecuteAsync(userId);

        // Assert
        Assert.NotNull(user);
        Assert.Equal("Test太郎", user.Name);
        Assert.Equal(20, user.Age);
    }
}