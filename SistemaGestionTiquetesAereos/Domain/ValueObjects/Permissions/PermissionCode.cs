using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Permissions;

public sealed record PermissionCode
{
    public string Value { get; }

    public PermissionCode(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(PermissionCode), 80, 2, true);
    }

    public override string ToString() => Value;
}
