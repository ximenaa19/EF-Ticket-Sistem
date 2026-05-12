using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Airline : BaseEntity
{
    private Airline()
    {
        Name = string.Empty;
        IataCode = string.Empty;
    }

    public Airline(string name, string iataCode)
    {
        Validate(name, iataCode);

        Name = name.Trim();
        IataCode = iataCode.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public string Name { get; private set; }
    public string IataCode { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string name, string iataCode, bool isActive)
    {
        Validate(name, iataCode);

        Name = name.Trim();
        IataCode = iataCode.Trim().ToUpperInvariant();
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

    private static void Validate(string name, string iataCode)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDomainStateException("Airline name is required.");
        }

        if (name.Trim().Length > 150)
        {
            throw new InvalidDomainStateException("Airline name cannot exceed 150 characters.");
        }

        if (string.IsNullOrWhiteSpace(iataCode) || iataCode.Trim().Length is < 2 or > 3)
        {
            throw new InvalidDomainStateException("Airline IATA code must contain two or three characters.");
        }
    }
}
