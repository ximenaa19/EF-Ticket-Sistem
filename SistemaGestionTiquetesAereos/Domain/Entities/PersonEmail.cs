using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class PersonEmail : BaseEntity
{
    private PersonEmail()
    {
        LocalPart = string.Empty;
    }

    public PersonEmail(Guid personId, Guid emailDomainId, string localPart, bool isPrimary)
    {
        Validate(personId, emailDomainId, localPart, isPrimary);

        PersonId = personId;
        EmailDomainId = emailDomainId;
        LocalPart = localPart.Trim();
        IsPrimary = isPrimary;
        IsActive = true;
    }

    public Guid PersonId { get; private set; }
    public Guid EmailDomainId { get; private set; }
    public string LocalPart { get; private set; }
    public bool IsPrimary { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid personId, Guid emailDomainId, string localPart, bool isPrimary, bool isActive)
    {
        Validate(personId, emailDomainId, localPart, isPrimary);

        PersonId = personId;
        EmailDomainId = emailDomainId;
        LocalPart = localPart.Trim();
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

    private static void Validate(Guid personId, Guid emailDomainId, string localPart, bool isPrimary)
    {
        if (personId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PersonId is required.");
        }

        if (emailDomainId == Guid.Empty)
        {
            throw new InvalidDomainStateException("EmailDomainId is required.");
        }

        if (string.IsNullOrWhiteSpace(localPart))
        {
            throw new InvalidDomainStateException("LocalPart is required.");
        }
        if (localPart.Trim().Length > 100)
        {
            throw new InvalidDomainStateException("LocalPart cannot exceed 100 characters.");
        }
    }
}
