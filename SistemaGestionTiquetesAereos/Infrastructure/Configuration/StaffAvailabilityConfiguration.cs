using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class StaffAvailabilityConfiguration : IEntityTypeConfiguration<StaffAvailability>
{
    public void Configure(EntityTypeBuilder<StaffAvailability> builder)
    {
        builder.ToTable("staff_availabilities");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.StaffId)
            .HasColumnName("staff_id")
            .IsRequired();

        builder.Property(entity => entity.AvailabilityStatusId)
            .HasColumnName("availability_status_id")
            .IsRequired();

        builder.Property(entity => entity.AvailableFrom)
            .HasColumnName("available_from")
            .IsRequired();

        builder.Property(entity => entity.AvailableTo)
            .HasColumnName("available_to")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Staff>()
            .WithMany()
            .HasForeignKey(entity => entity.StaffId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<AvailabilityStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.AvailabilityStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
