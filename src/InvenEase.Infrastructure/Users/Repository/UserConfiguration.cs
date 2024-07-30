using InvenEase.Domain.UserAggregate;
using InvenEase.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenEase.Infrastructure.Users.Repository;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
        ConfigureRolesTable(builder);
        ConfigurePermissionsTable(builder);
    }

    private static void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(u => u.Email)
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .HasMaxLength(50);

        builder.Property(u => u.FirstName)
            .HasMaxLength(50);

        builder.Property(u => u.Password);
    }

    private static void ConfigureRolesTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(u => u.Roles, rb =>
        {
            rb.ToTable("Roles");

            rb.WithOwner().HasForeignKey("UserId");

            rb.Property<int>("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", 0);

            rb.Property(r => r.Value)
                .HasColumnName("Role");
        });

        builder.Metadata.FindNavigation(nameof(User.Roles))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigurePermissionsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(u => u.Permissions, pb =>
        {
            pb.ToTable("Permissions");

            pb.WithOwner().HasForeignKey("UserId");

            pb.Property<int>("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", 0);

            pb.Property(p => p.Value)
                .HasColumnName("Permission");
        });

        builder.Metadata.FindNavigation(nameof(User.Permissions))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}