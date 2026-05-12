using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class AirlineConfiguration : IEntityTypeConfiguration<Airline>
{
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        builder.ToTable("airlines");

        builder.HasKey(airline => airline.Id);

        builder.Property(airline => airline.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(airline => airline.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(airline => airline.IataCode)
            .HasColumnName("iata_code")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(airline => airline.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(airline => airline.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(airline => airline.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(airline => airline.IataCode)
            .IsUnique();
    }
}
