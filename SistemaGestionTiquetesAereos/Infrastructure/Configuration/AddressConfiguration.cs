using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.RoadTypeId)
            .HasColumnName("road_type_id")
            .IsRequired();

        builder.Property(entity => entity.CityId)
            .HasColumnName("city_id")
            .IsRequired();

        builder.Property(entity => entity.Street)
            .HasColumnName("street")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(entity => entity.Number)
            .HasColumnName("number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(entity => entity.AdditionalInfo)
            .HasColumnName("additional_info")
            .HasMaxLength(250);

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<RoadType>()
            .WithMany()
            .HasForeignKey(entity => entity.RoadTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<City>()
            .WithMany()
            .HasForeignKey(entity => entity.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
