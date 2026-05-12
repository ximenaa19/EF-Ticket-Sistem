using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class PersonPhoneConfiguration : IEntityTypeConfiguration<PersonPhone>
{
    public void Configure(EntityTypeBuilder<PersonPhone> builder)
    {
        builder.ToTable("person_phones");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.PersonId)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(entity => entity.PhoneCodeId)
            .HasColumnName("phone_code_id")
            .IsRequired();

        builder.Property(entity => entity.Number)
            .HasColumnName("number")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(entity => entity.IsPrimary)
            .HasColumnName("is_primary")
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

        builder.HasOne<PhoneCode>()
            .WithMany()
            .HasForeignKey(entity => entity.PhoneCodeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
