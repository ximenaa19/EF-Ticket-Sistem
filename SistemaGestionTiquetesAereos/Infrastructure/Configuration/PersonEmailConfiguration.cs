using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class PersonEmailConfiguration : IEntityTypeConfiguration<PersonEmail>
{
    public void Configure(EntityTypeBuilder<PersonEmail> builder)
    {
        builder.ToTable("person_emails");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.PersonId)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(entity => entity.EmailDomainId)
            .HasColumnName("email_domain_id")
            .IsRequired();

        builder.Property(entity => entity.LocalPart)
            .HasColumnName("local_part")
            .HasMaxLength(100)
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

        builder.HasOne<EmailDomain>()
            .WithMany()
            .HasForeignKey(entity => entity.EmailDomainId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
