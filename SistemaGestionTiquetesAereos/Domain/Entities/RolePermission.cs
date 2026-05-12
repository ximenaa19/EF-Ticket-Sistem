using AirlineTicketSystem.Domain.Common;
using AirlineTicketSystem.Domain.Exceptions;

namespace AirlineTicketSystem.Domain.Entities;

public sealed class RolePermission : BaseEntity
{
    private RolePermission()
    {

    }

    public RolePermission(Guid roleId, Guid permissionId)
    {
        Validate(roleId, permissionId);

        RoleId = roleId;
        PermissionId = permissionId;
        IsActive = true;
    }

    public Guid RoleId { get; private set; }
    public Guid PermissionId { get; private set; }
    public bool IsActive { get; private set; }

    public void Update(Guid roleId, Guid permissionId, bool isActive)
    {
        Validate(roleId, permissionId);

        RoleId = roleId;
        PermissionId = permissionId;
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

    private static void Validate(Guid roleId, Guid permissionId)
    {
        if (roleId == Guid.Empty)
        {
            throw new InvalidDomainStateException("RoleId is required.");
        }

        if (permissionId == Guid.Empty)
        {
            throw new InvalidDomainStateException("PermissionId is required.");
        }
    }
}
