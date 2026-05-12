using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Roles;

public sealed record RoleCode
{
    public string Value { get; }

    public RoleCode(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(RoleCode), 80, 2, true);
    }

    public override string ToString() => Value;
}
