using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class FareConfiguration : IEntityTypeConfiguration<Fare>
{
    public void Configure(EntityTypeBuilder<Fare> builder)
    {
        builder.ToTable("fares");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.FlightId)
            .HasColumnName("flight_id")
            .IsRequired();

        builder.Property(entity => entity.PassengerTypeId)
            .HasColumnName("passenger_type_id")
            .IsRequired();

        builder.Property(entity => entity.CabinTypeId)
            .HasColumnName("cabin_type_id")
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

        builder.HasOne<Flight>()
            .WithMany()
            .HasForeignKey(entity => entity.FlightId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PassengerType>()
            .WithMany()
            .HasForeignKey(entity => entity.PassengerTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<CabinType>()
            .WithMany()
            .HasForeignKey(entity => entity.CabinTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
