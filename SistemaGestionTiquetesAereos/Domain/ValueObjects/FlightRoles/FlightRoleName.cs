using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.FlightRoles;

public sealed record FlightRoleName
{
    public string Value { get; }

    public FlightRoleName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(FlightRoleName), 80, 1, false);
    }

    public override string ToString() => Value;
}
