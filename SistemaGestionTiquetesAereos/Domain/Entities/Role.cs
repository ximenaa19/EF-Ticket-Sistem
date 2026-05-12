using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class Role : BaseEntity
{
    private Role()
    {
        Name = string.Empty;
        Code = string.Empty;
    }

    public Role(string name, string code)
    {
        Validate(name, code);

        Name = name.Trim();
        Code = code.Trim().ToUpperInvariant();
        IsActive = true;
    }

    public string Name { get; private set; }
    public string Code { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(string name, string code, bool isActive)
    {
        Validate(name, code);

        Name = name.Trim();
        Code = code.Trim().ToUpperInvariant();
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

    private static void Validate(string name, string code)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidDomainStateException("Name is required.");
        }
        if (name.Trim().Length > 100)
        {
            throw new InvalidDomainStateException("Name cannot exceed 100 characters.");
        }

        if (string.IsNullOrWhiteSpace(code))
        {
            throw new InvalidDomainStateException("Code is required.");
        }
        if (code.Trim().Length > 80)
        {
            throw new InvalidDomainStateException("Code cannot exceed 80 characters.");
        }
    }
}
