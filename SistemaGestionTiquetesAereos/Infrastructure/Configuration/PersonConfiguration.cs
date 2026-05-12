using AirlineTicketSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketSystem.Infrastructure.Configuration;

public sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("people");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(entity => entity.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(entity => entity.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(entity => entity.DocumentTypeId)
            .HasColumnName("document_type_id")
            .IsRequired();

        builder.Property(entity => entity.DocumentNumber)
            .HasColumnName("document_number")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(entity => entity.BirthDate)
            .HasColumnName("birth_date");

        builder.Property(entity => entity.AddressId)
            .HasColumnName("address_id");

        builder.Property(entity => entity.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(entity => entity.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(entity => entity.DocumentNumber)
            .IsUnique();

        builder.HasOne<DocumentType>()
            .WithMany()
            .HasForeignKey(entity => entity.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Address>()
            .WithMany()
            .HasForeignKey(entity => entity.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
