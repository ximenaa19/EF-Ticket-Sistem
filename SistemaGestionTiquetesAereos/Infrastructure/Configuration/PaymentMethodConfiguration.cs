using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("payment_methods");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.ClientId)
            .HasColumnName("client_id")
            .IsRequired();

        builder.Property(entity => entity.PaymentMethodTypeId)
            .HasColumnName("payment_method_type_id")
            .IsRequired();

        builder.Property(entity => entity.CardIssuerId)
            .HasColumnName("card_issuer_id");

        builder.Property(entity => entity.CardTypeId)
            .HasColumnName("card_type_id");

        builder.Property(entity => entity.MaskedNumber)
            .HasColumnName("masked_number")
            .HasMaxLength(30);

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Client>()
            .WithMany()
            .HasForeignKey(entity => entity.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PaymentMethodType>()
            .WithMany()
            .HasForeignKey(entity => entity.PaymentMethodTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<CardIssuer>()
            .WithMany()
            .HasForeignKey(entity => entity.CardIssuerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<CardType>()
            .WithMany()
            .HasForeignKey(entity => entity.CardTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
