using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("sessions");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(entity => entity.Token)
            .HasColumnName("token")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(entity => entity.ExpiresAt)
            .HasColumnName("expires_at")
            .IsRequired();

        builder.Property(entity => entity.RevokedAt)
            .HasColumnName("revoked_at");

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.Token)
            .IsUnique();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(entity => entity.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
