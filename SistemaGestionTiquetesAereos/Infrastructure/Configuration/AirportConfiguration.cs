using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.ToTable("airports");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(entity => entity.IataCode)
            .HasColumnName("iata_code")
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(entity => entity.IcaoCode)
            .HasColumnName("icao_code")
            .HasMaxLength(4)
            .IsRequired();

        builder.Property(entity => entity.CityId)
            .HasColumnName("city_id")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.IataCode)
            .IsUnique();

        builder.HasOne<City>()
            .WithMany()
            .HasForeignKey(entity => entity.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
