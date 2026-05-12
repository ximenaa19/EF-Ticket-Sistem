using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.ToTable("routes");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.OriginAirportId)
            .HasColumnName("origin_airport_id")
            .IsRequired();

        builder.Property(entity => entity.DestinationAirportId)
            .HasColumnName("destination_airport_id")
            .IsRequired();

        builder.Property(entity => entity.DistanceKm)
            .HasColumnName("distance_km")
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Airport>()
            .WithMany()
            .HasForeignKey(entity => entity.OriginAirportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Airport>()
            .WithMany()
            .HasForeignKey(entity => entity.DestinationAirportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
