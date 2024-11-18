using Microsoft.EntityFrameworkCore;
using TCTest.Infra;
using TCTest.Infra.Repository;

namespace TCTest.DomainService.Test;

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
        GetUserDS getUserDS = new(new UserRepository(db));

        // Act
        var users = await getUserDS.ExecuteAsync();

        // Assert
        Assert.NotNull(users);
    }
}