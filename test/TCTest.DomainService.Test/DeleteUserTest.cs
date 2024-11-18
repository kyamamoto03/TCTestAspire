using Microsoft.EntityFrameworkCore;
using TCTest.Infra;
using TCTest.Infra.Repository;

namespace TCTest.DomainService.Test;

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

        DeleteUserDS deleteUserDS = new DeleteUserDS(userRepository);
        GetUserAtDS getUserAtDS = new GetUserAtDS(userRepository);

        // Act
        await deleteUserDS.ExecuteAsync(userId);

        // Assert Exceptionが発生すること
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await getUserAtDS.ExecuteAsync(userId);
        });
    }
}