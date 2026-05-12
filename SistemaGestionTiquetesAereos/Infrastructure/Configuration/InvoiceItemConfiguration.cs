using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.ToTable("invoice_items");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.InvoiceId)
            .HasColumnName("invoice_id")
            .IsRequired();

        builder.Property(entity => entity.InvoiceItemTypeId)
            .HasColumnName("invoice_item_type_id")
            .IsRequired();

        builder.Property(entity => entity.Description)
            .HasColumnName("description")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(entity => entity.Amount)
            .HasColumnName("amount")
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

        builder.HasOne<Invoice>()
            .WithMany()
            .HasForeignKey(entity => entity.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<InvoiceItemType>()
            .WithMany()
            .HasForeignKey(entity => entity.InvoiceItemTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
