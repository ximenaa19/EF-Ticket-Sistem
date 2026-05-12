using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class City : BaseEntity
{
    private City()
    {
        Name = string.Empty;
    }

    public City(string name, Guid regionId)
    {
        Validate(name, regionId);

        Name = name.Trim();
        RegionId = regionId;
        IsActive = true;
    }

    public string Name { get; private set; }
    public Guid RegionId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string name, Guid regionId, bool isActive)
    {
        Validate(name, regionId);

        Name = name.Trim();
        RegionId = regionId;
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

    private static void Validate(string name, Guid regionId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDomainStateException("Name is required.");
        }
        if (name.Trim().Length > 120)
        {
            throw new InvalidDomainStateException("Name cannot exceed 120 characters.");
        }

        if (regionId == Guid.Empty)
        {
            throw new InvalidDomainStateException("RegionId is required.");
        }
    }
}
