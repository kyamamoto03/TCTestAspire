using Microsoft.EntityFrameworkCore;
using TCTest.Infra;
using TCTest.Infra.Repository;
using TCTest.WebApi.Apis;

namespace TCTest.WebApi.Test;

public class DeleteUserTest : DbInstance
{
    public TCTestDB CreateTcTestDB()
    {
        var _db = new TCTestDB(new DbContextOptionsBuilder<TCTestDB>()
           .UseNpgsql(DbConnectionString)
           .Options);

        return _db;
    }

    [Fact]
    public async Task データの削除()
    {
        // Arrange
        var db = CreateTcTestDB();
        var userRepository = new UserRepository(db);
        var userId = "USER01";

        // Act
        await UserApi.DeleteUserAsync(userId, userRepository);

        // Assert Exceptionが発生すること
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await UserApi.GetUserAtAsync(userId, userRepository);
        });
    }
}