using AirlineTicketSystem.Domain.ValueObjects.Shared;

namespace AirlineTicketSystem.Domain.ValueObjects.Aircraft;

public sealed record AircraftCapacity
{
    public int Value { get; }

    public AircraftCapacity(int value)
    {
        Value = ValueObjectGuards.Positive(value, nameof(AircraftCapacity));
    }
}
