using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class RouteStopConfiguration : IEntityTypeConfiguration<RouteStop>
{
    public void Configure(EntityTypeBuilder<RouteStop> builder)
    {
        builder.ToTable("route_stops");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.RouteId)
            .HasColumnName("route_id")
            .IsRequired();

        builder.Property(entity => entity.AirportId)
            .HasColumnName("airport_id")
            .IsRequired();

        builder.Property(entity => entity.StopOrder)
            .HasColumnName("stop_order")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Route>()
            .WithMany()
            .HasForeignKey(entity => entity.RouteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Airport>()
            .WithMany()
            .HasForeignKey(entity => entity.AirportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
