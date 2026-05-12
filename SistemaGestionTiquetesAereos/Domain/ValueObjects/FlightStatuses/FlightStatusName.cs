using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.FlightStatuses;

public sealed record FlightStatusName
{
    public string Value { get; }

    public FlightStatusName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(FlightStatusName), 80, 1, false);
    }

    public override string ToString() => Value;
}
