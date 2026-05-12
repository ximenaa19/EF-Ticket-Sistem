using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class CheckInConfiguration : IEntityTypeConfiguration<CheckIn>
{
    public void Configure(EntityTypeBuilder<CheckIn> builder)
    {
        builder.ToTable("check_ins");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.TicketId)
            .HasColumnName("ticket_id")
            .IsRequired();

        builder.Property(entity => entity.CheckInStatusId)
            .HasColumnName("check_in_status_id")
            .IsRequired();

        builder.Property(entity => entity.SeatId)
            .HasColumnName("seat_id");

        builder.Property(entity => entity.CheckedInAt)
            .HasColumnName("checked_in_at")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Ticket>()
            .WithMany()
            .HasForeignKey(entity => entity.TicketId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<CheckInStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.CheckInStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<FlightSeat>()
            .WithMany()
            .HasForeignKey(entity => entity.SeatId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
