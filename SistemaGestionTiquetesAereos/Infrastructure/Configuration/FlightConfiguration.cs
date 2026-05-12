using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable("flights");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.FlightCode)
            .HasColumnName("flight_code")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(entity => entity.AirlineId)
            .HasColumnName("airline_id")
            .IsRequired();

        builder.Property(entity => entity.RouteId)
            .HasColumnName("route_id")
            .IsRequired();

        builder.Property(entity => entity.AircraftId)
            .HasColumnName("aircraft_id")
            .IsRequired();

        builder.Property(entity => entity.DepartureDate)
            .HasColumnName("departure_date")
            .IsRequired();

        builder.Property(entity => entity.EstimatedArrivalDate)
            .HasColumnName("estimated_arrival_date")
            .IsRequired();

        builder.Property(entity => entity.TotalCapacity)
            .HasColumnName("total_capacity")
            .IsRequired();

        builder.Property(entity => entity.AvailableSeats)
            .HasColumnName("available_seats")
            .IsRequired();

        builder.Property(entity => entity.FlightStatusId)
            .HasColumnName("flight_status_id")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.FlightCode)
            .IsUnique();

        builder.HasOne<Airline>()
            .WithMany()
            .HasForeignKey(entity => entity.AirlineId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Route>()
            .WithMany()
            .HasForeignKey(entity => entity.RouteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Aircraft>()
            .WithMany()
            .HasForeignKey(entity => entity.AircraftId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<FlightStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.FlightStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
