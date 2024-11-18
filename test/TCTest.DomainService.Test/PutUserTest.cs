using Microsoft.EntityFrameworkCore;
using TCTest.Infra;
using TCTest.Infra.Repository;

namespace TCTest.DomainService.Test;

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

        var UserId = "USER01";
        string Name = "Test更新";
        int Age = 22;

        UpdateUserDS updateUserDS = new(userRepository);
        GetUserAtDS getUserAtDS = new(userRepository);

        // Act
        await updateUserDS.ExecuteAsync(UserId, Name, Age);

        var user = await getUserAtDS.ExecuteAsync(UserId);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(Name, user.Name);
        Assert.Equal(Age, user.Age);
    }
}