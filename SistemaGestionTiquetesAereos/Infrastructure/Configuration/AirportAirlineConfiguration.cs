using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class AirportAirlineConfiguration : IEntityTypeConfiguration<AirportAirline>
{
    public void Configure(EntityTypeBuilder<AirportAirline> builder)
    {
        builder.ToTable("airport_airlines");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.AirportId)
            .HasColumnName("airport_id")
            .IsRequired();

        builder.Property(entity => entity.AirlineId)
            .HasColumnName("airline_id")
            .IsRequired();

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
            .HasForeignKey(entity => entity.AirportId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Airline>()
            .WithMany()
            .HasForeignKey(entity => entity.AirlineId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
