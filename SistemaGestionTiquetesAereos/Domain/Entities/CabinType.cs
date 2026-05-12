using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class CabinType : BaseEntity
{
    private CabinType()
    {
        Name = string.Empty;
    }

    public CabinType(string name)
    {
        Validate(name);

        Name = name.Trim();
        IsActive = true;
    }

    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string name, bool isActive)
    {
        Validate(name);

        Name = name.Trim();
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

    private static void Validate(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDomainStateException("Name is required.");
        }
        if (name.Trim().Length > 80)
        {
            throw new InvalidDomainStateException("Name cannot exceed 80 characters.");
        }
    }
}
