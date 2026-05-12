using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("tickets");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.ReservationId)
            .HasColumnName("reservation_id")
            .IsRequired();

        builder.Property(entity => entity.PassengerId)
            .HasColumnName("passenger_id")
            .IsRequired();

        builder.Property(entity => entity.FlightId)
            .HasColumnName("flight_id")
            .IsRequired();

        builder.Property(entity => entity.TicketStatusId)
            .HasColumnName("ticket_status_id")
            .IsRequired();

        builder.Property(entity => entity.TicketNumber)
            .HasColumnName("ticket_number")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(entity => entity.FareAmount)
            .HasColumnName("fare_amount")
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(entity => entity.Currency)
            .HasColumnName("currency")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.TicketNumber)
            .IsUnique();

        builder.HasOne<Reservation>()
            .WithMany()
            .HasForeignKey(entity => entity.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Passenger>()
            .WithMany()
            .HasForeignKey(entity => entity.PassengerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Flight>()
            .WithMany()
            .HasForeignKey(entity => entity.FlightId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<TicketStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.TicketStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
