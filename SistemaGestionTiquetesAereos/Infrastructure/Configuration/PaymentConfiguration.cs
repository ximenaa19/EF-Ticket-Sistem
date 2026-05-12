using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.ReservationId)
            .HasColumnName("reservation_id")
            .IsRequired();

        builder.Property(entity => entity.PaymentMethodId)
            .HasColumnName("payment_method_id")
            .IsRequired();

        builder.Property(entity => entity.PaymentStatusId)
            .HasColumnName("payment_status_id")
            .IsRequired();

        builder.Property(entity => entity.Amount)
            .HasColumnName("amount")
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(entity => entity.Currency)
            .HasColumnName("currency")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(entity => entity.PaidAt)
            .HasColumnName("paid_at");

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

        builder.HasOne<PaymentMethod>()
            .WithMany()
            .HasForeignKey(entity => entity.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PaymentStatus>()
            .WithMany()
            .HasForeignKey(entity => entity.PaymentStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
