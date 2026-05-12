using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class ReservationFlightConfiguration : IEntityTypeConfiguration<ReservationFlight>
{
    public void Configure(EntityTypeBuilder<ReservationFlight> builder)
    {
        builder.ToTable("reservation_flights");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.ReservationId)
            .HasColumnName("reservation_id")
            .IsRequired();

        builder.Property(entity => entity.FlightId)
            .HasColumnName("flight_id")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Reservation>()
            .WithMany()
            .HasForeignKey(entity => entity.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Flight>()
            .WithMany()
            .HasForeignKey(entity => entity.FlightId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
