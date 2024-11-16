using Microsoft.EntityFrameworkCore;
using TCTest.Domain.SeedOfWork;
using TCTest.Domain.UserModel;
using TCTest.Infra.Configuration;

namespace TCTest.Infra;

public class TCTestDB : DbContext, IUnitOfWork
{
    public TCTestDB(DbContextOptions<TCTestDB> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    public DbSet<User> Users { get; set; } = null!;
}