using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCTest.Domain.UserModel;

namespace TCTest.Infra.Configuration;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user_info");
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.UserId).HasColumnName("user_id");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.Age).HasColumnName("age");
    }
}