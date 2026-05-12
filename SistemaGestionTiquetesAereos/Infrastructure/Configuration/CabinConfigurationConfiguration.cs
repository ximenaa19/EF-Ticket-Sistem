using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class CabinConfigurationConfiguration : IEntityTypeConfiguration<CabinConfiguration>
{
    public void Configure(EntityTypeBuilder<CabinConfiguration> builder)
    {
        builder.ToTable("cabin_configurations");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.AircraftId)
            .HasColumnName("aircraft_id")
            .IsRequired();

        builder.Property(entity => entity.CabinTypeId)
            .HasColumnName("cabin_type_id")
            .IsRequired();

        builder.Property(entity => entity.SeatCount)
            .HasColumnName("seat_count")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Aircraft>()
            .WithMany()
            .HasForeignKey(entity => entity.AircraftId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<CabinType>()
            .WithMany()
            .HasForeignKey(entity => entity.CabinTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
