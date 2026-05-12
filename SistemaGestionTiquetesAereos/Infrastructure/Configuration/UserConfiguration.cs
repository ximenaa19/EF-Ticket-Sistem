using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.PersonId)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(entity => entity.RoleId)
            .HasColumnName("role_id")
            .IsRequired();

        builder.Property(entity => entity.UserName)
            .HasColumnName("user_name")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(entity => entity.PasswordHash)
            .HasColumnName("password_hash")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.UserName)
            .IsUnique();

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(entity => entity.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Role>()
            .WithMany()
            .HasForeignKey(entity => entity.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
