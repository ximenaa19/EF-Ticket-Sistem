using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Continent : BaseEntity
{
    private Continent()
    {
        Name = string.Empty;
    }

    public Continent(string name)
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
            throw new InvalidDomainStateException("Continent name is required.");
        }

        if (name.Trim().Length > 100)
        {
            throw new InvalidDomainStateException("Continent name cannot exceed 100 characters.");
        }
    }
}
