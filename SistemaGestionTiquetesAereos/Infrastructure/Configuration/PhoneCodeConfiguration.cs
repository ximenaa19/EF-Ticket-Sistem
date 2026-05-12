using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class PhoneCodeConfiguration : IEntityTypeConfiguration<PhoneCode>
{
    public void Configure(EntityTypeBuilder<PhoneCode> builder)
    {
        builder.ToTable("phone_codes");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.CountryId)
            .HasColumnName("country_id")
            .IsRequired();

        builder.Property(entity => entity.Code)
            .HasColumnName("code")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.Code)
            .IsUnique();

        builder.HasOne<Country>()
            .WithMany()
            .HasForeignKey(entity => entity.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
