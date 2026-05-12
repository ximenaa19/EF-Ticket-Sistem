using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Person : BaseEntity
{
    private Person()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        DocumentNumber = string.Empty;
    }

    public Person(string firstName, string lastName, Guid documentTypeId, string documentNumber, DateTime? birthDate, Guid? addressId)
    {
        Validate(firstName, lastName, documentTypeId, documentNumber, birthDate, addressId);

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        DocumentTypeId = documentTypeId;
        DocumentNumber = documentNumber.Trim();
        BirthDate = birthDate;
        AddressId = addressId;
        IsActive = true;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid DocumentTypeId { get; private set; }
    public string DocumentNumber { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public Guid? AddressId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string firstName, string lastName, Guid documentTypeId, string documentNumber, DateTime? birthDate, Guid? addressId, bool isActive)
    {
        Validate(firstName, lastName, documentTypeId, documentNumber, birthDate, addressId);

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        DocumentTypeId = documentTypeId;
        DocumentNumber = documentNumber.Trim();
        BirthDate = birthDate;
        AddressId = addressId;
        IsActive = isActive;

        MarkAsUpdated();
    }

    public void Activate()
    {
        IsActive = true;
        MarkAsUpdated();
    }

    public void Deactivate()
    {
        IsActive = false;
        MarkAsUpdated();
    }

    private static void Validate(string firstName, string lastName, Guid documentTypeId, string documentNumber, DateTime? birthDate, Guid? addressId)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new InvalidDomainStateException("FirstName is required.");
        }
        if (firstName.Trim().Length > 100)
        {
            throw new InvalidDomainStateException("FirstName cannot exceed 100 characters.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new InvalidDomainStateException("LastName is required.");
        }
        if (lastName.Trim().Length > 100)
        {
            throw new InvalidDomainStateException("LastName cannot exceed 100 characters.");
        }

        if (documentTypeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("DocumentTypeId is required.");
        }

        if (string.IsNullOrWhiteSpace(documentNumber))
        {
            throw new InvalidDomainStateException("DocumentNumber is required.");
        }
        if (documentNumber.Trim().Length > 40)
        {
            throw new InvalidDomainStateException("DocumentNumber cannot exceed 40 characters.");
        }
    }
}
