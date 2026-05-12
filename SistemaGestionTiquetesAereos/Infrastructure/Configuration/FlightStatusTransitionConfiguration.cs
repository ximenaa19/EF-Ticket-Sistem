using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class FlightStatusTransitionConfiguration : IEntityTypeConfiguration<FlightStatusTransition>
{
    public void Configure(EntityTypeBuilder<FlightStatusTransition> builder)
    {
        builder.ToTable("flight_status_transitions");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.FlightId)
            .HasColumnName("flight_id")
            .IsRequired();

        builder.Property(entity => entity.FromFlightStatusId)
            .HasColumnName("from_flight_status_id")
            .IsRequired();

        builder.Property(entity => entity.ToFlightStatusId)
            .HasColumnName("to_flight_status_id")
            .IsRequired();

        builder.Property(entity => entity.ChangedAt)
            .HasColumnName("changed_at")
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

        builder.HasOne<FlightStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.FromFlightStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<FlightStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.ToFlightStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
