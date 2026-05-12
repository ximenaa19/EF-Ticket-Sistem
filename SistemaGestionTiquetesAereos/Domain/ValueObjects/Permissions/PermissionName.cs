using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Permissions;

public sealed record PermissionName
{
    public string Value { get; }

    public PermissionName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PermissionName), 120, 1, false);
    }

    public override string ToString() => Value;
}
