using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Airport : BaseEntity
{
    private Airport()
    {
        Name = string.Empty;
        IataCode = string.Empty;
        IcaoCode = string.Empty;
    }

    public Airport(string name, string iataCode, string icaoCode, Guid cityId)
    {
        Validate(name, iataCode, icaoCode, cityId);

        Name = name.Trim();
        IataCode = iataCode.Trim().ToUpperInvariant();
        IcaoCode = icaoCode.Trim().ToUpperInvariant();
        CityId = cityId;
        IsActive = true;
    }

    public string Name { get; private set; }
    public string IataCode { get; private set; }
    public string IcaoCode { get; private set; }
    public Guid CityId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string name, string iataCode, string icaoCode, Guid cityId, bool isActive)
    {
        Validate(name, iataCode, icaoCode, cityId);

        Name = name.Trim();
        IataCode = iataCode.Trim().ToUpperInvariant();
        IcaoCode = icaoCode.Trim().ToUpperInvariant();
        CityId = cityId;
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

    private static void Validate(string name, string iataCode, string icaoCode, Guid cityId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDomainStateException("Name is required.");
        }
        if (name.Trim().Length > 150)
        {
            throw new InvalidDomainStateException("Name cannot exceed 150 characters.");
        }

        if (string.IsNullOrWhiteSpace(iataCode))
        {
            throw new InvalidDomainStateException("IataCode is required.");
        }
        if (iataCode.Trim().Length > 3)
        {
            throw new InvalidDomainStateException("IataCode cannot exceed 3 characters.");
        }

        if (string.IsNullOrWhiteSpace(icaoCode))
        {
            throw new InvalidDomainStateException("IcaoCode is required.");
        }
        if (icaoCode.Trim().Length > 4)
        {
            throw new InvalidDomainStateException("IcaoCode cannot exceed 4 characters.");
        }

        if (cityId == Guid.Empty)
        {
            throw new InvalidDomainStateException("CityId is required.");
        }
    }
}
