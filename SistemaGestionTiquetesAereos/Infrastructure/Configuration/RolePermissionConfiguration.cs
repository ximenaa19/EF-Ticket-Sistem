using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("role_permissions");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.RoleId)
            .HasColumnName("role_id")
            .IsRequired();

        builder.Property(entity => entity.PermissionId)
            .HasColumnName("permission_id")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Role>()
            .WithMany()
            .HasForeignKey(entity => entity.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Permission>()
            .WithMany()
            .HasForeignKey(entity => entity.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
