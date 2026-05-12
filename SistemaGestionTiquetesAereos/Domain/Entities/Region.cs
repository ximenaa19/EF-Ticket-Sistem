using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Region : BaseEntity
{
    private Region()
    {
        Name = string.Empty;
    }

    public Region(string name, Guid countryId)
    {
        Validate(name, countryId);

        Name = name.Trim();
        CountryId = countryId;
        IsActive = true;
    }

    public string Name { get; private set; }
    public Guid CountryId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string name, Guid countryId, bool isActive)
    {
        Validate(name, countryId);

        Name = name.Trim();
        CountryId = countryId;
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

    private static void Validate(string name, Guid countryId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDomainStateException("Name is required.");
        }
        if (name.Trim().Length > 100)
        {
            throw new InvalidDomainStateException("Name cannot exceed 100 characters.");
        }

        if (countryId == Guid.Empty)
        {
            throw new InvalidDomainStateException("CountryId is required.");
        }
    }
}
