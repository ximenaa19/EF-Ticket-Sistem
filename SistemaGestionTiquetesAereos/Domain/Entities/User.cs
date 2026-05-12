using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class User : BaseEntity
{
    private User()
    {
        UserName = string.Empty;
        PasswordHash = string.Empty;
    }

    public User(Guid personId, Guid roleId, string userName, string passwordHash)
    {
        Validate(personId, roleId, userName, passwordHash);

        PersonId = personId;
        RoleId = roleId;
        UserName = userName.Trim();
        PasswordHash = passwordHash.Trim();
        IsActive = true;
    }

    public Guid PersonId { get; private set; }
    public Guid RoleId { get; private set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid personId, Guid roleId, string userName, string passwordHash, bool isActive)
    {
        Validate(personId, roleId, userName, passwordHash);

        PersonId = personId;
        RoleId = roleId;
        UserName = userName.Trim();
        PasswordHash = passwordHash.Trim();
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

    private static void Validate(Guid personId, Guid roleId, string userName, string passwordHash)
    {
        if (personId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PersonId is required.");
        }

        if (roleId == Guid.Empty)
        {
            throw new InvalidDomainStateException("RoleId is required.");
        }

        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new InvalidDomainStateException("UserName is required.");
        }
        if (userName.Trim().Length > 80)
        {
            throw new InvalidDomainStateException("UserName cannot exceed 80 characters.");
        }

        if (string.IsNullOrWhiteSpace(passwordHash))
        {
            throw new InvalidDomainStateException("PasswordHash is required.");
        }
        if (passwordHash.Trim().Length > 250)
        {
            throw new InvalidDomainStateException("PasswordHash cannot exceed 250 characters.");
        }
    }
}
