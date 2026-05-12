using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.ToTable("passengers");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.PersonId)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(entity => entity.PassengerTypeId)
            .HasColumnName("passenger_type_id")
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(entity => entity.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PassengerType>()
            .WithMany()
            .HasForeignKey(entity => entity.PassengerTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
