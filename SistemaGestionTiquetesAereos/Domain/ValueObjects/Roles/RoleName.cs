using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Roles;

public sealed record RoleName
{
    public string Value { get; }

    public RoleName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(RoleName), 100, 1, false);
    }

    public override string ToString() => Value;
}
