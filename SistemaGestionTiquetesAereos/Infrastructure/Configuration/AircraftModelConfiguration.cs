using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class AircraftModelConfiguration : IEntityTypeConfiguration<AircraftModel>
{
    public void Configure(EntityTypeBuilder<AircraftModel> builder)
    {
        builder.ToTable("aircraft_models");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.Name)
            .HasColumnName("name")
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(entity => entity.AircraftManufacturerId)
            .HasColumnName("aircraft_manufacturer_id")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.Name)
            .IsUnique();

        builder.HasOne<AircraftManufacturer>()
            .WithMany()
            .HasForeignKey(entity => entity.AircraftManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
