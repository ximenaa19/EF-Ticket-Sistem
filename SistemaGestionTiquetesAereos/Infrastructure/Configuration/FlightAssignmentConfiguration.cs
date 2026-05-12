using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class FlightAssignmentConfiguration : IEntityTypeConfiguration<FlightAssignment>
{
    public void Configure(EntityTypeBuilder<FlightAssignment> builder)
    {
        builder.ToTable("flight_assignments");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.FlightId)
            .HasColumnName("flight_id")
            .IsRequired();

        builder.Property(entity => entity.StaffId)
            .HasColumnName("staff_id")
            .IsRequired();

        builder.Property(entity => entity.FlightRoleId)
            .HasColumnName("flight_role_id")
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

        builder.HasOne<Staff>()
            .WithMany()
            .HasForeignKey(entity => entity.StaffId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<FlightRole>()
            .WithMany()
            .HasForeignKey(entity => entity.FlightRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
