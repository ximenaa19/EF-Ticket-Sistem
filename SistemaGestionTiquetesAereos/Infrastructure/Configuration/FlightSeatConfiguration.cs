using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class FlightSeatConfiguration : IEntityTypeConfiguration<FlightSeat>
{
    public void Configure(EntityTypeBuilder<FlightSeat> builder)
    {
        builder.ToTable("flight_seats");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.FlightId)
            .HasColumnName("flight_id")
            .IsRequired();

        builder.Property(entity => entity.SeatNumber)
            .HasColumnName("seat_number")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(entity => entity.CabinTypeId)
            .HasColumnName("cabin_type_id")
            .IsRequired();

        builder.Property(entity => entity.SeatLocationTypeId)
            .HasColumnName("seat_location_type_id")
            .IsRequired();

        builder.Property(entity => entity.AvailabilityStatusId)
            .HasColumnName("availability_status_id")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Flight>()
            .WithMany()
            .HasForeignKey(entity => entity.FlightId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<CabinType>()
            .WithMany()
            .HasForeignKey(entity => entity.CabinTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<SeatLocationType>()
            .WithMany()
            .HasForeignKey(entity => entity.SeatLocationTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<AvailabilityStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.AvailabilityStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
