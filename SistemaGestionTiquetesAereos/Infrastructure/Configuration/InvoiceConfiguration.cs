using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("invoices");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.ReservationId)
            .HasColumnName("reservation_id")
            .IsRequired();

        builder.Property(entity => entity.InvoiceNumber)
            .HasColumnName("invoice_number")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(entity => entity.IssuedAt)
            .HasColumnName("issued_at")
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

        builder.HasIndex(entity => entity.InvoiceNumber)
            .IsUnique();

        builder.HasOne<Reservation>()
            .WithMany()
            .HasForeignKey(entity => entity.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
