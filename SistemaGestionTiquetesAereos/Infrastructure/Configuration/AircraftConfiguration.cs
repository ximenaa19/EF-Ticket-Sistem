using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
{
    public void Configure(EntityTypeBuilder<Aircraft> builder)
    {
        builder.ToTable("aircraft");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.RegistrationNumber)
            .HasColumnName("registration_number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(entity => entity.AirlineId)
            .HasColumnName("airline_id")
            .IsRequired();

        builder.Property(entity => entity.AircraftModelId)
            .HasColumnName("aircraft_model_id")
            .IsRequired();

        builder.Property(entity => entity.AvailabilityStatusId)
            .HasColumnName("availability_status_id")
            .IsRequired();

        builder.Property(entity => entity.TotalCapacity)
            .HasColumnName("total_capacity")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.RegistrationNumber)
            .IsUnique();

        builder.HasOne<Airline>()
            .WithMany()
            .HasForeignKey(entity => entity.AirlineId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<AircraftModel>()
            .WithMany()
            .HasForeignKey(entity => entity.AircraftModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<AvailabilityStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.AvailabilityStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
