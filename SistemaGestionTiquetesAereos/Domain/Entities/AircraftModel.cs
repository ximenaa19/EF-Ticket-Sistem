using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class AircraftModel : BaseEntity
{
    private AircraftModel()
    {
        Name = string.Empty;
    }

    public AircraftModel(string name, Guid aircraftManufacturerId)
    {
        Validate(name, aircraftManufacturerId);

        Name = name.Trim();
        AircraftManufacturerId = aircraftManufacturerId;
        IsActive = true;
    }

    public string Name { get; private set; }
    public Guid AircraftManufacturerId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string name, Guid aircraftManufacturerId, bool isActive)
    {
        Validate(name, aircraftManufacturerId);

        Name = name.Trim();
        AircraftManufacturerId = aircraftManufacturerId;
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

    private static void Validate(string name, Guid aircraftManufacturerId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDomainStateException("Name is required.");
        }
        if (name.Trim().Length > 120)
        {
            throw new InvalidDomainStateException("Name cannot exceed 120 characters.");
        }

        if (aircraftManufacturerId == Guid.Empty)
        {
            throw new InvalidDomainStateException("AircraftManufacturerId is required.");
        }
    }
}
