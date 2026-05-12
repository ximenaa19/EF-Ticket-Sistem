using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class PersonPhone : BaseEntity
{
    private PersonPhone()
    {
        Number = string.Empty;
    }

    public PersonPhone(Guid personId, Guid phoneCodeId, string number, bool isPrimary)
    {
        Validate(personId, phoneCodeId, number, isPrimary);

        PersonId = personId;
        PhoneCodeId = phoneCodeId;
        Number = number.Trim();
        IsPrimary = isPrimary;
        IsActive = true;
    }

    public Guid PersonId { get; private set; }
    public Guid PhoneCodeId { get; private set; }
    public string Number { get; private set; }
    public bool IsPrimary { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid personId, Guid phoneCodeId, string number, bool isPrimary, bool isActive)
    {
        Validate(personId, phoneCodeId, number, isPrimary);

        PersonId = personId;
        PhoneCodeId = phoneCodeId;
        Number = number.Trim();
        IsPrimary = isPrimary;
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

    private static void Validate(Guid personId, Guid phoneCodeId, string number, bool isPrimary)
    {
        if (personId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PersonId is required.");
        }

        if (phoneCodeId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PhoneCodeId is required.");
        }

        if (string.IsNullOrWhiteSpace(number))
        {
            throw new InvalidDomainStateException("Number is required.");
        }
        if (number.Trim().Length > 30)
        {
            throw new InvalidDomainStateException("Number cannot exceed 30 characters.");
        }
    }
}
