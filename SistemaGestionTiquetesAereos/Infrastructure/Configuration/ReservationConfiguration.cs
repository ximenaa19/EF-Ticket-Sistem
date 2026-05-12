using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("reservations");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.ClientId)
            .HasColumnName("client_id")
            .IsRequired();

        builder.Property(entity => entity.ReservationStatusId)
            .HasColumnName("reservation_status_id")
            .IsRequired();

        builder.Property(entity => entity.ReservationCode)
            .HasColumnName("reservation_code")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(entity => entity.ReservedAt)
            .HasColumnName("reserved_at")
            .IsRequired();

        builder.Property(entity => entity.TotalAmount)
            .HasColumnName("total_amount")
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

        builder.HasIndex(entity => entity.ReservationCode)
            .IsUnique();

        builder.HasOne<Client>()
            .WithMany()
            .HasForeignKey(entity => entity.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ReservationStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.ReservationStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
