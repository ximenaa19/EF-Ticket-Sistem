using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.AircraftModels;

public sealed record AircraftModelName
{
    public string Value { get; }

    public AircraftModelName(string value)
    {
        Value = ValueObjectGuards.RequiredText(value, nameof(AircraftModelName), 120, 1, false);
    }

    public override string ToString() => Value;
}
