using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Country : BaseEntity
{
    private Country()
    {
        Name = string.Empty;
        IsoCode = string.Empty;
    }

    public Country(string name, string isoCode, Guid continentId)
    {
        Validate(name, isoCode, continentId);

        Name = name.Trim();
        IsoCode = isoCode.Trim().ToUpperInvariant();
        ContinentId = continentId;
        IsActive = true;
    }

    public string Name { get; private set; }
    public string IsoCode { get; private set; }
    public Guid ContinentId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string name, string isoCode, Guid continentId, bool isActive)
    {
        Validate(name, isoCode, continentId);

        Name = name.Trim();
        IsoCode = isoCode.Trim().ToUpperInvariant();
        ContinentId = continentId;
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

    private static void Validate(string name, string isoCode, Guid continentId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDomainStateException("Name is required.");
        }
        if (name.Trim().Length > 100)
        {
            throw new InvalidDomainStateException("Name cannot exceed 100 characters.");
        }

        if (string.IsNullOrWhiteSpace(isoCode))
        {
            throw new InvalidDomainStateException("IsoCode is required.");
        }
        if (isoCode.Trim().Length > 3)
        {
            throw new InvalidDomainStateException("IsoCode cannot exceed 3 characters.");
        }

        if (continentId == Guid.Empty)
        {
            throw new InvalidDomainStateException("ContinentId is required.");
        }
    }
}
