using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class ReservationStatusTransitionConfiguration : IEntityTypeConfiguration<ReservationStatusTransition>
{
    public void Configure(EntityTypeBuilder<ReservationStatusTransition> builder)
    {
        builder.ToTable("reservation_status_transitions");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.ReservationId)
            .HasColumnName("reservation_id")
            .IsRequired();

        builder.Property(entity => entity.FromReservationStatusId)
            .HasColumnName("from_reservation_status_id")
            .IsRequired();

        builder.Property(entity => entity.ToReservationStatusId)
            .HasColumnName("to_reservation_status_id")
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

        builder.HasOne<Reservation>()
            .WithMany()
            .HasForeignKey(entity => entity.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ReservationStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.FromReservationStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ReservationStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.ToReservationStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
