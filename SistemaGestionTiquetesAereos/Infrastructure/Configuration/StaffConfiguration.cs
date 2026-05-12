using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.ToTable("staff");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.PersonId)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(entity => entity.StaffPositionId)
            .HasColumnName("staff_position_id")
            .IsRequired();

        builder.Property(entity => entity.EmployeeCode)
            .HasColumnName("employee_code")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.EmployeeCode)
            .IsUnique();

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(entity => entity.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<StaffPosition>()
            .WithMany()
            .HasForeignKey(entity => entity.StaffPositionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
