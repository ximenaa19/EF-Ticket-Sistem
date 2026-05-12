using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class ContinentConfiguration : IEntityTypeConfiguration<Continent>
{
    public void Configure(EntityTypeBuilder<Continent> builder)
    {
        builder.ToTable("continents");

        builder.HasKey(continent => continent.Id);

        builder.Property(continent => continent.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(continent => continent.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(continent => continent.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(continent => continent.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(continent => continent.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(continent => continent.Name)
            .IsUnique();
    }
}
